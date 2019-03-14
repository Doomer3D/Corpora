using System;
using System.Collections.Generic;
using System.IO;

namespace Corpora
{
    /// <summary>
    /// генератор словаря
    /// </summary>
    public class DictionaryGenerator
    {
        /// <summary>
        /// настройки генератора
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public DictionaryGenerator()
        {
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="options"> настройки генератора </param>
        public DictionaryGenerator(Options options)
        {
            this.Options = options;
        }

        /// <summary>
        /// запустить генератор
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
        }
    }
}
