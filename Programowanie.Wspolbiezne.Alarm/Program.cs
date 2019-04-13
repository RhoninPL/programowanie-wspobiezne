using System;

namespace Programowanie.Wspolbiezne.Alarm
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dateTime = DateTime.Now;
            Console.WriteLine("Podaj godzine:");
            var hours = Console.ReadLine();
            Console.WriteLine("Podaj minute:");
            var minutes = Console.ReadLine();
            var timeSpan = new TimeSpan(int.Parse(hours), int.Parse(minutes), 0);
            dateTime = dateTime.Date + timeSpan;

            var alarm = new Alarm
            {
                Action = MyAlarm
            };
            alarm.Run(dateTime);

            Console.ReadKey();
        }

        public static void MyAlarm()
        {
            Console.WriteLine($"Godzina {DateTime.Now}. Alarm!");
        }
    }
}