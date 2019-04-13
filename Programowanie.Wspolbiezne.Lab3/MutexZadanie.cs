using System;
using System.IO;
using System.Threading;

namespace Programowanie.Wspolbiezne.Lab3
{
    public class MutexZadanie
    {
        private readonly Mutex mutex = new Mutex(false, "{88D94D34-D225-4052-BBA3-EE59C645F0AF}");
        public void Run()
        {
            Console.WriteLine("Czekam");
            mutex.WaitOne();
            Console.Clear();
            Console.Write("Wpisuję ");
            try
            {
                var file = File.AppendText(@"test.log");

                for (var i = 0; i < 100; i++)
                {
                    file.WriteLine(
                        $"{i} Id: {System.Diagnostics.Process.GetCurrentProcess().Id}, Time: {DateTime.Now}");
                    file.Flush();
                    Thread.Sleep(100);
                    Console.Write(".");
                }

                file.Close();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("Nie znaleziono pliku.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            mutex.ReleaseMutex();
            Console.WriteLine("KONIEC");
        }
    }
}