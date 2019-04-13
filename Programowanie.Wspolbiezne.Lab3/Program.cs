using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programowanie.Wspolbiezne.Lab3
{
    class Program
    {
        public static void Main()
        {
            new PieciuFilozofow().Run();
            Console.ReadKey();
        }
    }
}
