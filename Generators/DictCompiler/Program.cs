using System;

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
#if !DEBUG
                    try
                    {
#endif
                    new DawgCompiler(opts).Run();
                    //new DictionaryGenerator(opts).Run();
#if !DEBUG
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
#endif
                });
        }
    }
}
