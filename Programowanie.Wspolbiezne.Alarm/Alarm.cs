using System;
using System.Timers;

namespace Programowanie.Wspolbiezne.Alarm
{
    public class Alarm
    {
        public Action Action;

        public void Run(DateTime dateTime)
        {
            var timer = new Timer(100);
            timer.Elapsed += (sender, elapsedEventArgs) => TimerOnElapsed(sender, elapsedEventArgs, dateTime);
            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs, DateTime dateTime)
        {
            if (elapsedEventArgs.SignalTime > dateTime)
                Action();
        }
    }
}