using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Programowanie.Wspolbiezne.LiczbyDoskonale
{
    class Program
    {
        public static object obiekt = new object();
        public static string[] linie = File.ReadAllLines(@"liczby.csv");
        public static int i;
        public static void Main()
        {
            var t2 = new Thread(new ThreadStart(Wyswietl));
            var t3 = new Thread(new ThreadStart(Szukaj));
            t2.IsBackground = true;
            t3.IsBackground = true;
            t2.Start();
            t3.Start();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            { }
            t2.Abort();
            t3.Abort();

            Console.ReadKey();
        }

        public static void Wyswietl()
        {
            while (i < linie.Length)
            {
                lock (obiekt)
                {
                    double procent = 0;
                    if (i > 0)
                        procent = (float)i / linie.Length;
                    
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Postęp: Nr rekordu: {i:D6} z {linie.Length:D6} Procent: {procent:P2}");
                    Thread.Sleep(200);
                }
            }
        }

        public static void Szukaj()
        {
            int miejsce = 3;
            lock (obiekt)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Szukam liczb doskonałych (ESC - przerwij)");
            }
            for (i = 0; i < linie.Length; i++)
            {
                var linia = linie[i];

                lock (obiekt)
                {
                    if (CzyDoskonala(int.Parse(linia)))
                    {
                        Console.SetCursorPosition(0, miejsce++);
                        Console.WriteLine($"Liczba {linia} na pozycji nr {i}");
                    }
                }
            }
        }

        private static bool CzyDoskonala(int liczba)
        {
            int podzielnik = 1, sumapodzielnikow = 0;
            while (podzielnik < liczba)
            {
                if (liczba % podzielnik == 0)
                    sumapodzielnikow += podzielnik;
                podzielnik++;
            }

            return (liczba == sumapodzielnikow);
        }
    }
}
