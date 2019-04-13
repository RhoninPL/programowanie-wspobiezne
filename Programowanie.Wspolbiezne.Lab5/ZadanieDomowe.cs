using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Lab5
{
    public class ZadanieDomowe
    {
        public void Run()
        {
            int start = System.Environment.TickCount;

            //for (int i = 0; i < 100000; i++)
            //{
            //    Random random = new Random();
            //    var numbers = new List<int>();
            //    for (int j = 0; j < 1000; j++)
            //        numbers.Add(random.Next(j));
            //}
            // Czas wykonania  2 656 ms

            Parallel.For(0, 100000, (i) =>
            {
                Random random = new Random();
                var numbers = new List<int>();
                for (int j = 0; j < 1000; j++)
                    numbers.Add(random.Next(j));
            });
            //Czas wykonania 1 266 ms

            int stop = System.Environment.TickCount;
            Console.WriteLine("Czas wykonania {0} ms", (stop - start).ToString("N0"));
        }

        public int GetMedian(int[] Value)
        {
            decimal Median = 0;
            var size = Value.Length;
            var mid = size / 2;
            Median = (size % 2 != 0) ? (decimal) Value[mid] : ((decimal) Value[mid] + (decimal) Value[mid + 1]) / 2;

            return Convert.ToInt32(Math.Round(Median));
        }

}
}