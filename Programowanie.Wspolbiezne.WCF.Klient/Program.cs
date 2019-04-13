using System;
using System.ServiceModel;

namespace Programowanie.Wspolbiezne.WCF.Klient
{
    internal class Program
    {
        #region Public Methods

        private static void Main(string[] args)
        {
            var adres = new Uri("http://localhost:2222/Hello");
            using (var c = new ChannelFactory<IHelloWorld>(new BasicHttpBinding(),new EndpointAddress(adres))){
                var s = c.CreateChannel();
                Console.WriteLine(s.Hello());
                Console.ReadLine();
            }
        }

        #endregion
    }
}