using System;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Asynchroniczne
{
    class Program
    {
        static void Main(string[] args)
        {
            WynikObliczen();
            WprowadzanieDanych();
            Console.ReadKey();
        }

        public static int Oblicz()
        {
            // Długotrwałe obliczenia
            double x = 2;
            for (int i = 1; i < 100000000; i++)
                x += Math.Sqrt(x) / i;
            return (int)x;
        }

        static Task<int> ObliczAsync()
        {
            return Task.Run(() => Oblicz());
        }

        public static async void WynikObliczen()
        {
            int result = await ObliczAsync();
            Console.WriteLine("Wynik obliczeń {0}", result);
        }

        public static void WprowadzanieDanych()
        {
            Console.WriteLine("Wprowadź 5 liczb");
            int licznik = 0, suma = 0;
            do
            {
                suma += int.Parse(Console.ReadLine());
                licznik++;
            } while (licznik < 5);
            Console.WriteLine("Suma wprowadzonych liczb {0}", suma);
        }
    }

}
