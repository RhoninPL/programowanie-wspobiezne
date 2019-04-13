using System;
using System.Threading;

namespace Programowanie.Wspolbiezne.Lab4
{
    public class KonsumenciProducenci
    {
        static object obiektSynchronizacjiMagazynu = new object();
        static object obiektSynchronizacjiProducenta = new object();
        static object obiektSynchronizacjiKonsumenta = new object();

        static Random r = new Random();

        static Thread watekProducenta = null;
        static Thread watekKonsumenta = null;

        const int maksymalnyCzasProdukcji = 100;
        const int maksymalnyCzasKonsumpcji = 100;
        const int maksymalnyCzasUruchomieniaProdukcji = 500;
        const int maksymalnyCzasUruchomieniaKonsumpcji = 500;

        static int pojemnoscMagazynu = 5;
        static int licznikElementowWMagazynie = 1;

        static void wyswietlStanMagazynu()
        {
            Console.WriteLine("Liczba elementów w magazynie: {0}", licznikElementowWMagazynie);
        }

        public void Pracuj()
        {
            // wyrażenie lambda dla akcji producenta
            watekProducenta = new Thread(() =>
            {
                do
                {
                    try
                    {
                        Monitor.Enter(obiektSynchronizacjiMagazynu);
                        if (licznikElementowWMagazynie == pojemnoscMagazynu)
                        {
                            Monitor.Wait(obiektSynchronizacjiMagazynu);
                            Thread.Sleep(r.Next(maksymalnyCzasUruchomieniaProdukcji));
                        }

                        Monitor.Enter(obiektSynchronizacjiProducenta);
                        Thread.Sleep(r.Next(maksymalnyCzasProdukcji));
                        licznikElementowWMagazynie++;
                        Console.WriteLine($"{Thread.CurrentThread.Name} Utworzenie produktu.");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Exception: {exception}");
                    }
                    finally
                    {
                        Monitor.Pulse(obiektSynchronizacjiMagazynu);
                        Monitor.Exit(obiektSynchronizacjiMagazynu);
                        Monitor.Exit(obiektSynchronizacjiProducenta);
                    }
                } while (true);
            });

            // wyrażenie lambda dla akcji konsumenta
            watekKonsumenta = new Thread(() =>
            {
                do
                {
                    try
                    {
                        Monitor.Enter(obiektSynchronizacjiMagazynu);
                        if (licznikElementowWMagazynie == 0)
                        {
                            Monitor.Wait(obiektSynchronizacjiMagazynu);
                            Thread.Sleep(r.Next(maksymalnyCzasUruchomieniaKonsumpcji));
                        }

                        Monitor.Enter(obiektSynchronizacjiKonsumenta);
                        Thread.Sleep(r.Next(maksymalnyCzasKonsumpcji));
                        licznikElementowWMagazynie--;
                        Console.WriteLine($"{Thread.CurrentThread.Name} Konsumowanie produktu.");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Exception: {exception}");
                    }
                    finally
                    {
                        Monitor.Exit(obiektSynchronizacjiKonsumenta);
                        Monitor.Pulse(obiektSynchronizacjiMagazynu);
                        Monitor.Exit(obiektSynchronizacjiMagazynu);
                    }
                } while (true);
            });

            var wyswietl = new Thread(() =>
            {
                while (true)
                {
                    Monitor.Enter(obiektSynchronizacjiMagazynu);
                    wyswietlStanMagazynu();
                    Monitor.Exit(obiektSynchronizacjiMagazynu);
                    Thread.Sleep(1000);
                }
            });

            // Utworzenie obu wątków i uruchomienie ich jako wątków tła
            watekProducenta.IsBackground = true;
            watekKonsumenta.IsBackground = true;
            wyswietl.IsBackground = true;

            watekProducenta.Start();
            watekKonsumenta.Start();
            wyswietl.Start();

            Console.ReadLine();
            Console.WriteLine("!!! Koniec !!!");
            wyswietlStanMagazynu();
        }
    }
}