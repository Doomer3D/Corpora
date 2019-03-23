using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;

using Corpora.Formats.Xml;
using Corpora.QuickDAWG;

namespace Corpora
{
    /// <summary>
    /// компилятор DAWG
    /// </summary>
    public class DawgCompiler
    {
        /// <summary>
        /// настройки компилятора
        /// </summary>
        public Options Options { get; set; }

        private MaximumSubstring _maximumSubstring = new MaximumSubstring();

        /// <summary>
        /// конструктор
        /// </summary>
        public DawgCompiler()
        {
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="options"> настройки компилятора </param>
        public DawgCompiler(Options options)
        {
            this.Options = options;
        }

        /// <summary>
        /// запустить компилятор
        /// </summary>
        public void Run()
        {
            ////////////////////////////////////////////////////////////////
            // проверяем настройки
            ////////////////////////////////////////////////////////////////

            // файл словаря
            var dictPath = Options.DictPath;
            if (string.IsNullOrWhiteSpace(dictPath)) throw new Exception("Не указан файл словаря");

            dictPath = dictPath.Trim();
            dictPath = Path.GetFullPath(Path.IsPathRooted(dictPath) ? dictPath : Path.Combine(AppContext.BaseDirectory, dictPath));
            if (!File.Exists(dictPath)) throw new FileNotFoundException($"Файл словаря на найден: {dictPath}", dictPath);

            // выходной файл
            var outputFileName = Options.OutputFileName;
            outputFileName = Path.GetFullPath(Path.IsPathRooted(outputFileName) ? outputFileName : Path.Combine(AppContext.BaseDirectory, outputFileName));
            var outputDirectory = Path.GetDirectoryName(outputFileName);
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);

            ////////////////////////////////////////////////////////////////
            // читаем данные
            ////////////////////////////////////////////////////////////////

            var builder = new DawgBuilder();

            //builder.Add("fox", default, default);
            //builder.Add("box", default, default);
            //builder.Add("foxes", default, default);
            //builder.Add("boxes", default, default);
            //builder.Add("boxer", default, default);

            //builder.Add("ёж", default, default);
            //builder.Add("ежа", default, default);
            //builder.Add("ежу", default, default);
            //builder.Add("ежа", default, default);

            //builder.Add("салл", default, default);
            //builder.Add("салло", default, default);
            //builder.Add("саллой", default, default);
            //builder.Add("велиор", default, default);
            //builder.Add("велита", default, default);
            //builder.Add("велиулла", default, default);
            //builder.Add("велиуллы", default, default);
            //builder.Add("велиуллe", default, default);
            //builder.Add("велиуллу", default, default);
            //builder.Add("велиуллой", default, default);

            //Console.WriteLine($"Всего вершин в графе: {builder.CountNodes()}");

#if DEBUG
            var memoryUsageBefore = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            var sw = new Stopwatch();
            sw.Start();
#endif

            using (var stream = File.Open(dictPath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new OpenCorporaDictionaryReader(stream))
                {
                    int lexemeCount = 0;

                    reader.OnLexeme += item =>
                    {
                        if (++lexemeCount % 10000 == 0)
                        {
                            GC.Collect();
                            Console.Write('.');
                        }
                        ProcessLexeme(builder, item);
                    };

                    reader.ReadAll();
                }
            }
            Console.WriteLine();

            // производим реиндексацию сущностей для сжатия
            builder.Reindex();
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            sw.Stop();

            Console.WriteLine($"Всего вершин в графе: {builder.CountNodes()}");

#if DEBUG
            var memoryUsageAfter = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            Console.WriteLine($"Использовано памяти: {(memoryUsageAfter - memoryUsageBefore) / (1 << 20)} Мб");
            Console.WriteLine($"Общее время:: {sw.Elapsed.TotalSeconds:0.0} с");
#endif
        }

        /// <summary>
        /// обработать лексему
        /// </summary>
        /// <param name="builder"> построитель графа </param>
        /// <param name="lexeme"> лексема </param>
        private void ProcessLexeme(DawgBuilder builder, Lexeme lexeme)
        {
            // извлекаем стем
            var stem = _maximumSubstring.FindMaximumSubstring(lexeme.Forms.Select(e => e.Text));
            var stemLength = stem.Length;

            string prefixString, suffixString;
            WeightedString prefix, suffix;
            Tag tag;

            int count = lexeme.Forms.Count, i = 0;
            var prefixes = new WeightedString[count];
            var suffixes = new WeightedString[count];
            var tags = new Tag[count];

            // идентификатор тега леммы (применяется ко всем формам)
            var lemmaTag = builder.GetTag(lexeme.Lemma.Grammemes);

            // цикл по формам слова
            foreach (var (text, grammemes) in lexeme.Forms)
            {
                if (stemLength == 0)
                {
                    // пустой стем
                    prefixString = text;
                    suffixString = "";
                }
                else
                {
                    int pos = text.IndexOf(stem);
                    prefixString = text.Substring(0, pos);
                    suffixString = text.Substring(pos + stemLength);
                }

                prefix = builder.GetPrefix(prefixString);
                suffix = builder.GetSuffix(suffixString);
                tag = builder.GetTag(grammemes);

                prefixes[i] = prefix;
                suffixes[i] = suffix;
                tags[i] = tag;

                i++;
            }

            // получаем парадигму
            var paradigm = builder.GetParadigm(prefixes, suffixes, tags);

            // наполняем граф
            for (i = 0; i < count; i++)
            {
                builder.Add(prefixes[i] + stem + suffixes[i], paradigm, i);
            }
        }
    }
}
