using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri adress = new Uri("http://localhost:2222/Hello");
            ServiceHost host = new ServiceHost(typeof(HelloWorld), adress);
            host.AddServiceEndpoint(typeof(IHelloWorld), new BasicHttpBinding(), adress);
            host.Open();

            Console.WriteLine("Serwer uruchomiony");
            Console.ReadKey();
        }
    }
}
