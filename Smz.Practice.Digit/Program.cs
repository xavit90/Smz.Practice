using System.Globalization;
using Humanizer;

namespace Smz.Practice.Digit;
class Program
{
    static void Main(string[] args)
    {
        // Numero en texto 
        // Console.WriteLine(OperatingSystem.IsWindows());
        if (args.Any())
        {
            if (int.TryParse(args[0], out var number))
            {
                Console.WriteLine(NumberToWordsExtension.ToWords(number, new CultureInfo("es")));
                Console.WriteLine($"Super Dígito: {SuperDigito(number)}");
            }
            else
            {
                Console.WriteLine($"\"{args[0]}\" No corresponde a un número");
            }
        }
    }

    static int SuperDigito(int numero)
    {
        while (numero >= 10)
        {
            int suma = 0;
            while (numero > 0)
            {
                suma += numero % 10;
                numero /= 10;
            }
            numero = suma;
        }
        return numero;
    }
}