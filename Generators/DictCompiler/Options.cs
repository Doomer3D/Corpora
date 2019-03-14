using System;

using CommandLine;

namespace Corpora
{
    /// <summary>
    /// настройки генератора
    /// </summary>
    public class Options
    {
        /// <summary>
        /// путь к словарю OpenCorpora
        /// </summary>
        [Option('d', "dict", Required = false, Default = "dict.opcorpora.xml", HelpText = "OpenCorpora dictionary path.")]
        public string DictPath { get; set; }

        /// <summary>
        /// путь к выходным данным
        /// </summary>
        [Value(0, MetaName = "OutputPath", Required = true)]
        public string OutputFileName { get; set; }
    }
}
