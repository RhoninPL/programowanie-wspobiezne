using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Lab5
{
    public class Zadanie1
    {
        const int ileWatkow = 10;
        Barrier b = new Barrier(ileWatkow, (Barrier b) => { Console.WriteLine(); });

        public void Run()
        {
            Action metodaWatku = () =>
            {
                for (char znak = 'A'; znak <= 'G'; znak++)
                {
                    Console.Write(znak);
                    b.SignalAndWait();
                }
            };

            List<Task> tab = new List<Task>();
            for (int i = 0; i < ileWatkow; i++)
            {
                tab.Add(new Task(metodaWatku));
            }
            tab.ForEach(task => task.Start());
            tab.ForEach(task => task.Wait());

        }
    }
}