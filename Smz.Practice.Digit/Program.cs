using System.Globalization;
using Humanizer;

namespace Smz.Practice.Digit;
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine(OperatingSystem.IsWindows());
        if (args.Any())
        {
            if (int.TryParse(args[0], out var number))
                Console.WriteLine(NumberToWordsExtension.ToWords(number, new CultureInfo("es")));
            else
                Console.WriteLine($"\"{args[0]}\" No corresponde a un número");
        }
    }
}