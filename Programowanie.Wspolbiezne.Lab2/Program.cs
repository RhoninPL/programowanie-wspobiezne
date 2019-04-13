using System;
using System.Threading;

namespace Programowanie.Wspolbiezne.Lab2
{
    public class Program
    {

        public static object obiekt = new object();
        public static void Main()
        {
            var t2 = new Thread(new ParameterizedThreadStart(OdliczajBiale));   // definicja wątku
            t2.Start(ConsoleColor.White);

            OdliczajCzerowone(ConsoleColor.Red);    // Wywolanie metody odliczajacej w pierwszym watku

            Console.ReadKey();
        }

        public static void OdliczajBiale(object color)
        {
            for (int i = 1000; i > 0; i--)
            {
                lock (obiekt)
                {
                    Console.ForegroundColor = (ConsoleColor)color;
                    Console.Write(i.ToString() + " ");
                }
            }
        }

        public static void OdliczajCzerowone(ConsoleColor color)
        {
            for (int i = 1000; i > 0; i--)
            {
                lock (obiekt)
                {
                    Console.ForegroundColor = color;
                    Console.Write(i.ToString() + " ");
                }
            }
        }
    }
}
