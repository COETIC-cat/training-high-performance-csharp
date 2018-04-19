using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensiveStringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            var a = "function";
            var b = "too";
            var c = "this";
            var d = "this";
            var e = "this";
            var f = "this";
            var g = "this";

            //var a = 1;
            //var b = 2;
            //var c = 3;
            //var d = 4;
            //var e = 5;
            //var f = 6;
            //var g = 7;

            int N_LOOPS = 1000000;
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < N_LOOPS; i++)
            {
                result = String.Format("This {0} could become {1} costly if {2} and {3} and {4} and {5} and {6} stings are concatenated",
                    a,
                    b,
                    c,
                    d,
                    e,
                    f,
                    g);
            }
            timer.Stop();
            Console.WriteLine("String format took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < N_LOOPS; i++)
            {
                result = $"This {a} could become {b} costly if {c} and {d} and {e} and {f} and {g} stings are concatenated";
            }
            timer.Stop();
            Console.WriteLine("String format with $ operator took: " + timer.ElapsedMilliseconds);
            
            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < N_LOOPS; i++)
            {
                result = "This " + a + " could become " + b + " costly if " + c + " and " + d + " and " + e + " and " + f + " and " + g + " stings are concatenated";
            }
            timer.Stop();
            Console.WriteLine("String concatenation with variables took: " + timer.ElapsedMilliseconds);
        }
    }
}

