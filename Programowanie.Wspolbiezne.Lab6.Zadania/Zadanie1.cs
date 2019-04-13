using System;
using System.IO;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Lab6.Zadania
{
    public class Zadanie1
    {
        public void Run()
        {
            var task1 = GetStringLength("http://bossa.pl/pub/ciagle/omega/cgl/ndohlcv.txt");
            var task2 = GetStringLength("http://bossa.pl/pub/newconnect/omega/ncn/ndohlcv.txt");
            Task.WaitAll(task1, task2);
            File.WriteAllText("ilosc.txt", (task1.Result + task2.Result).ToString());
            Console.WriteLine("Zapisano");
        }

        public void Run2()
        {
            var task1 = GetString("http://bossa.pl/pub/ciagle/omega/cgl/ndohlcv.txt");
            var task2 = GetString("http://bossa.pl/pub/newconnect/omega/ncn/ndohlcv.txt");
            Task.WaitAny(task1, task2);
            File.WriteAllText("tekst.txt", task1.IsCompleted ? task1.Result : task2.Result);
            
            Console.WriteLine("Zapisano");
        }

        public async Task<int> GetStringLength(string url)
        {
            var adres = new Uri(url);
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(adres);

            return result.Length;
        }

        public async Task<string> GetString(string url)
        {
            var adres = new Uri(url);
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(adres);

            return result;
        }
    }
}