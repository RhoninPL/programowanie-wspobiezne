using System;
using System.Threading;

namespace Programowanie.Wspolbiezne.Lab3
{
    public class MonitorZadanie
    {
        public static string tekst = string.Empty;
        public static object obiekt = new object();
        public static void Run()
        {
            var t2 = new Thread(new ThreadStart(Czytajacy));
            t2.Name = "Watek czytajacy: ";

            var t3 = new Thread(new ThreadStart(Piszacy));
            t3.Name = "Watek piszacy: ";
            t2.Start();
            t3.Start();

            Console.ReadKey();
        }

        public static void Czytajacy()
        {
            Monitor.Enter(obiekt);
            if (tekst == string.Empty)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} brak wiadomości");
                Console.WriteLine($"{Thread.CurrentThread.Name} czekaj");
                Monitor.Wait(obiekt);
            }

            Console.WriteLine($"{Thread.CurrentThread.Name}Pozdrowienia otrzymane: {tekst}");
            Monitor.Exit(obiekt);
        }

        public static void Piszacy()
        {
            Monitor.Enter(obiekt);
            tekst = "Pozdrowienia!";
            Console.WriteLine($"{Thread.CurrentThread.Name}Pozdrowienia wysłane. ");
            Monitor.Pulse(obiekt);
            Monitor.Exit(obiekt);
        }
    }
}