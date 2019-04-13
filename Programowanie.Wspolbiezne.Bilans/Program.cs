using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Bilans
{

    class Program
    {

        public static int bilans = 100;
        public static object obiekt = new object();
        public static void Main()
        {
            var t2 = new Thread(new ThreadStart(Odejmuj));   // definicja wątku
            t2.Start();

            var t3 = new Thread(new ThreadStart(Dodawaj));   // definicja wątku
            t3.Start();

            Console.ReadKey();
        }

        public static void Odejmuj()
        {
            for (int i = 0; i < 20; i++)
            {

                Monitor.Enter(obiekt);
                if (bilans <= 0)
                    Monitor.Wait(obiekt);

                bilans -= 100;
                Console.WriteLine($"Bilans po odjęciu: {bilans}");
                Monitor.Exit(obiekt);
            }
        }

        public static void Dodawaj()
        {
            for (int i = 0; i < 20; i++)
            {
                Monitor.Enter(obiekt);
                bilans += 100;
                if(bilans > 0)
                    Monitor.Pulse(obiekt);

                Console.WriteLine($"Bilns po dodaniu: {bilans}");
                Monitor.Exit(obiekt);
            }
        }

    }
}
