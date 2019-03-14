using System;
using System.Collections.Generic;
using System.Text;

namespace Corpora
{
    /// <summary>
    /// генератор словаря
    /// </summary>
    public class DictionaryGenerator
    {
        /// <summary>
        /// путь к входным данным
        /// </summary>
        public string InputPath { get; set; }

        /// <summary>
        /// путь к выходным данным
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public DictionaryGenerator()
        {
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="inputPath"> путь к входным данным </param>
        /// <param name="outputPath"> путь к выходным данным </param>
        public DictionaryGenerator(string inputPath, string outputPath)
        {
            this.InputPath = inputPath;
            this.OutputPath = outputPath;
        }

        /// <summary>
        /// запустить генератор
        /// </summary>
        public void Run()
        {
        }
    }
}
