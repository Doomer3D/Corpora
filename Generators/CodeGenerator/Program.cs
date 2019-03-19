using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Corpora
{
    class Program
    {
        /// <summary>
        /// сгенерировать файл G.generated.cs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Не указан путь к выходному каталогу");
                return;
            }

            // определяем путь к выходному каталогу
            var pathPart = args[0];
            var path = Path.GetFullPath(Path.IsPathRooted(pathPart) ? pathPart : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, args[0]));

            // создаем каталог, если он еще не существует
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            // генерируем файл с описанием граммем
            GenerateGrammemes(path);

            // генерируем файл с описанием типов связей
            GenerateLinkTypes(path);
        }

        /// <summary>
        /// генерировать файл с описанием граммем
        /// </summary>
        /// <param name="path"> путь </param>
        private static void GenerateGrammemes(string path)
        {
            ////////////////////////////////////////////////////////////////
            // читаем файл с описанием граммем
            ////////////////////////////////////////////////////////////////

            byte id = 0;
            var dic = new Dictionary<string, ExtendedGrammeme>();

            var doc = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "grammemes.xml"));
            foreach (XElement node in doc.Element("grammemes").Nodes())
            {
                dic.TryGetValue(node.Attribute("parent").Value, out ExtendedGrammeme parent);
                var item = new ExtendedGrammeme(++id, FormatName(node.Element("name").Value), node.Element("alias").Value, Capitalize(node.Element("description").Value), parent)
                {
                    OriginName = node.Element("name").Value
                };
                dic[item.Name] = item;
            }

            ////////////////////////////////////////////////////////////////
            // генерируем файл с описанием граммем
            ////////////////////////////////////////////////////////////////

            var grammemeClassName = nameof(Grammeme);
            var className = nameof(G);
            var items = dic.Values.OrderBy(e => e.ID);

            var sb = new StringBuilder();

            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace {nameof(Corpora)}");
            sb.AppendLine("{");
            sb.AppendLine($"    public static partial class {className}");
            sb.AppendLine("    {");

            // статические свойства
            foreach (var item in items)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine($"        /// {item.Description}");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine($"        /// <remarks> {nameof(item.ID)} = {item.ID} </remarks>");
                sb.AppendLine($"        public static {grammemeClassName} {item.Name} {{ get; private set; }}");
                sb.AppendLine();
            }

            // статический конструктор
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// статический конструктор");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine($"        static {className}()");
            sb.AppendLine("        {");
            foreach (var item in items)
            {
                sb.Append($"            {item.Name} = new {grammemeClassName}({item.ID}, {QuoteString(item.OriginName)}, {QuoteString(item.Alias)}, {QuoteString(item.Description)}");
                if (item.Parent != null)
                {
                    sb.Append($", {item.Parent.Name}");
                }
                sb.AppendLine(");");
            }
            sb.AppendLine("            ");
            sb.AppendLine("            // инициализируем коллекции");
            sb.AppendLine($"            _grammemes = new List<{grammemeClassName}>({dic.Count});");
            sb.AppendLine($"            _grammemesByID = new Dictionary<byte, {grammemeClassName}>({dic.Count});");
            sb.AppendLine($"            _grammemesByName = new Dictionary<string, {grammemeClassName}>({dic.Count});");
            sb.AppendLine("            ");
            sb.AppendLine("            // регистрируем граммемы");
            sb.AppendLine("            {");
            foreach (var item in items)
            {
                sb.AppendLine($"                Register({item.Name});");
            }
            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            // сохраняем код
            File.WriteAllText(Path.Combine(path, $"{className}.generated.cs"), sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// генерировать файл с описанием типов связей
        /// </summary>
        /// <param name="path"> путь </param>
        private static void GenerateLinkTypes(string path)
        {
            ////////////////////////////////////////////////////////////////
            // читаем файл с описанием граммем
            ////////////////////////////////////////////////////////////////

            var dic = new Dictionary<string, ExtendedLinkType>();

            var doc = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "links.xml"));
            foreach (XElement node in doc.Element("link_types").Nodes())
            {
                var item = new ExtendedLinkType(byte.Parse(node.Attribute("id").Value), FormatName(node.Value))
                {
                    OriginName = node.Value
                };
                dic[item.Name] = item;
            }

            ////////////////////////////////////////////////////////////////
            // генерируем файл с описанием граммем
            ////////////////////////////////////////////////////////////////
            
            var className = nameof(LinkType);
            var items = dic.Values.OrderBy(e => e.ID);

            var sb = new StringBuilder();

            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace {nameof(Corpora)}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {className}");
            sb.AppendLine("    {");

            // статические свойства
            foreach (var item in items)
            {
                sb.AppendLine("        /// <summary>");
                sb.AppendLine($"        /// {item.OriginName}");
                sb.AppendLine("        /// </summary>");
                sb.AppendLine($"        /// <remarks> {nameof(item.ID)} = {item.ID} </remarks>");
                sb.AppendLine($"        public static {className} {item.Name} {{ get; private set; }}");
                sb.AppendLine();
            }

            // статический конструктор
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// статический конструктор");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine($"        static {className}()");
            sb.AppendLine("        {");
            foreach (var item in items)
            {
                sb.AppendLine($"            {item.Name} = new {className}({item.ID}, {QuoteString(item.OriginName)});");
            }
            sb.AppendLine("            ");
            sb.AppendLine("            // инициализируем коллекции");
            sb.AppendLine($"            _links = new List<{className}>({dic.Count});");
            sb.AppendLine($"            _linksByID = new Dictionary<byte, {className}>({dic.Count});");
            sb.AppendLine("            ");
            sb.AppendLine("            // регистрируем типы связей");
            sb.AppendLine("            {");
            foreach (var item in items)
            {
                sb.AppendLine($"                Register({item.Name});");
            }
            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            // сохраняем код
            File.WriteAllText(Path.Combine(path, $"{className}.generated.cs"), sb.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// сделать начальную букву строки заглавной
        /// </summary>
        /// <param name="value"> строка </param>
        /// <returns></returns>
        private static string Capitalize(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            value = value.Trim();
            if (value.Length <= 1) return value.ToUpperInvariant();
            else return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// форматировать имя
        /// </summary>
        /// <param name="value"> строка </param>
        /// <returns></returns>
        private static string FormatName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            // убираем минусы
            value = value.Replace('-', '_');

            // убираем начальне цифры
            if (char.IsDigit(value[0]))
            {
                value = value.Substring(1) + value[0];
            }

            return value;
        }

        /// <summary>
        /// заключить строку в кавычки
        /// </summary>
        /// <param name="value"> строка </param>
        /// <returns></returns>
        private static string QuoteString(string value)
        {
            if (value == null) return "null";

            var sb = new StringBuilder(value.Length + 2);

            sb.Append('"');
            foreach (char c in value)
            {
                if (c == '\\' || c == '"')
                {
                    sb.Append('\\');
                }
                sb.Append(c);
            }
            sb.Append('"');

            return sb.ToString();
        }
    }
}
