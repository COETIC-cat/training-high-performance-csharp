using GenericsPerformanceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericsPerformanceTest
{
    public struct Struct1<T>
    {
        public int SomeNumber;
        public T SomeObject;
        public int AnotherNumber;
    }

    public struct Struct2<T>
    {
        public int SomeNumber;
        public int AnotherNumber;
        public T SomeObject;
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int N_OBJECTS = 10000000;
            long result = 0;

            var c1 = new Struct1<long>[N_OBJECTS];
            //var c1 = new Struct2<long>[N_OBJECTS];

            for (int i = 0; i < N_OBJECTS; i++)
                result += Marshal.SizeOf(c1[i]);

            Console.WriteLine("Total size of array allocated in memory: " + result);
            Console.WriteLine("Number of garbage collections: " + GC.CollectionCount(0));
        }
        
    }
}
