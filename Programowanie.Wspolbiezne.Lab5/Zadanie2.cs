using System;
using System.Threading;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Lab5
{
    public class Zadanie2
    {
        private Random random = new Random();
        public void Run()
        {
            var t1 = new Task(() =>
            {
                Thread.Sleep(random.Next(1000, 2000));
                Console.WriteLine("t1");
            });
            var t2 = new Task(() =>
            {
                Thread.Sleep(random.Next(1000, 2000));
                Console.WriteLine("t2");
            });
            var t3 = new Task(() => {
                Thread.Sleep(random.Next(500, 500));
                Console.WriteLine("t3");
            });
            var t4 = new Task(() =>
            {
                Thread.Sleep(random.Next(2000, 3000));
                Console.WriteLine("t4");
            });
            t1.Start();
            t2.Start();
            t1.ContinueWith((task) => t3.Start());
            t2.ContinueWith((task) => t4.Start());


            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine("Done");
        }
    }
}