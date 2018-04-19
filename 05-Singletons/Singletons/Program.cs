using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singletons
{
    class Program
    {
        static public string[] GetElements1()
        {
            return Array.Empty<string>();
        }

        static public string[] GetElements2()
        {
            return new string[0];
        }

        static void Main(string[] args)
        {
            const int MAX_ELEMENTS = 10000000;
            for (int i = 0; i < MAX_ELEMENTS; i++)
            {
                // Swap commented line to see the difference.
                //var elements = GetElements1();
                var elements = GetElements2();

                foreach (var element in elements)
                {
                    Console.WriteLine("We shouldn't write anything");
                }
            }
            Console.WriteLine("Number of garbage collections: " + GC.CollectionCount(0));
        }
    }
}
