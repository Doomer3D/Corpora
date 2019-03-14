﻿using System;

using CommandLine;

namespace Corpora
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts =>
                {
                    // запускаем генератор
                    try
                    {
                        new DictionaryGenerator(opts).Run();
                    }
                    catch (Exception ex)
                    {
                        // выводим информацию об ошибке
                        var color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR!");
                        Console.ForegroundColor = color;

                        Console.WriteLine();
                        Console.WriteLine("Message:");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("StackTrace:");
                        Console.WriteLine(ex.StackTrace);
                    }
                });

            //if (args == null || args.Length == 0)
            //{
            //    Console.WriteLine("Не указан путь к выходному каталогу");
            //    return;
            //}

            //// определяем путь к входному файлу
            //var inputPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dict.opcorpora.xml"));

            //// определяем путь к выходному каталогу
            //var pathPart = args[0];
            //var outputPath = Path.GetFullPath(Path.IsPathRooted(pathPart) ? pathPart : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, args[0]));

            //// создаем каталог, если он еще не существует
            //if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);

            //new DictionaryGenerator(inputPath, outputPath).Run();
        }
    }
}
