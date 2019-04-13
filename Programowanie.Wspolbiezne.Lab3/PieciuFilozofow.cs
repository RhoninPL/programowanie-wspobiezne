using System;
using System.Threading;

namespace Programowanie.Wspolbiezne.Lab3
{
    public class PieciuFilozofow
    {
        public static int iluNarazJe = 0;
        public static DateTime start = DateTime.Now;
        public static Random random = new Random();
        public static Semaphore[] Widelec =
        {
            new Semaphore(1, 1),
            new Semaphore(1, 1),
            new Semaphore(1, 1),
            new Semaphore(1, 1),
            new Semaphore(1, 1)
        };

        public static Semaphore Lokaj = new Semaphore(2,2);
        public void Run()
        {
            for (var i = 0; i < 5; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(Filozof));
                thread.Start(i);
            }
        }

        public void Filozof(object num)
        {
            do
            {
                Console.WriteLine($"Filozof {int.Parse(num.ToString())} myśli");
                Lokaj.WaitOne();
                Widelec[int.Parse(num.ToString())].WaitOne();
                Widelec[(int.Parse(num.ToString()) + 1) % 5].WaitOne();
                Thread.Sleep(random.Next(1, 10));

                Console.WriteLine($"Filozof {int.Parse(num.ToString())}  je");
                iluNarazJe++;
                Console.Title = $"Ilu jest naraz:{iluNarazJe}. Czas trwania programu {(DateTime.Now - start):g}";
                if(iluNarazJe >= 3)
                {
                    Console.WriteLine("3 naraz je!");
                    Console.ReadKey();
                }
                Widelec[(int.Parse(num.ToString()) + 1) % 5].Release();
                Widelec[int.Parse(num.ToString())].Release();
                Thread.Sleep(random.Next(1, 10));
                Lokaj.Release();
                iluNarazJe--;
            } while (true);
        }
    }
}