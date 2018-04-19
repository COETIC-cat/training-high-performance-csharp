using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerablePerformance
{
    public static class TestImplemnentation
    {
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return Enumerable.Where(source, predicate);
        }

        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            return Enumerable.ToList(source);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var filter = 1;
            var file = System.IO.File.OpenText(@"..\..\..\..\SampleData.txt");
            var list = new List<int>();
            var line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                list.Add(int.Parse(line));
                line = file.ReadLine();
            }

            var timer = System.Diagnostics.Stopwatch.StartNew();
            var filteredEnumerable = list.Where(x => (x > filter));

            var loops = 0;
            var n = filteredEnumerable.Count();
            n = filteredEnumerable.Count();

            foreach (var element in filteredEnumerable)
            {
                loops++;
            }
            timer.Stop();
            Console.WriteLine("Two counts and one loop using Enumerable took: " + timer.ElapsedMilliseconds);

            loops = 0;
            timer.Reset();
            timer.Start();
            var filteredList = list.Where(x => (x > filter)).ToList();
            n = filteredList.Count();
            n = filteredList.Count();

            foreach (var element in filteredList)
            {
                loops++;
            }

            timer.Stop();
            Console.WriteLine("Two counts and one loop using List took: " + timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            var isAny = list.Where(x => (x > filter)).Any();
            isAny = list.Where(x => (x > filter)).Any();
            isAny = list.Where(x => (x > filter)).Any();
            timer.Stop();
            Console.WriteLine("Any using Enumerable took: " + timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            filteredList = list.Where(x => (x > filter)).ToList();
            isAny = filteredList.Any();
            isAny = filteredList.Any();
            isAny = filteredList.Any();
            timer.Stop();
            Console.WriteLine("Any using list took: " + timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            n = list.Where(x => (x > filter)).Count();
            n = list.Where(x => (x > filter)).Count();
            n = list.Where(x => (x > filter)).Count();
            timer.Stop();
            Console.WriteLine("Three counts using Enumerable took: " + timer.ElapsedMilliseconds);
            timer.Reset();
            timer.Start();
            filteredList = list.Where(x => (x > filter)).ToList();
            n = filteredList.Count;
            n = filteredList.Count;
            n = filteredList.Count;
            timer.Stop();
            Console.WriteLine("Three counts using List took: " + timer.ElapsedMilliseconds);

            loops = 0;
            timer.Reset();
            timer.Start();
            foreach (var element in list.Where(x => (x > filter)))
            {
                loops++;
            }
            timer.Stop();
            Console.WriteLine("One loop using Enumerable took: " + timer.ElapsedMilliseconds);

            loops = 0;
            timer.Reset();
            timer.Start();
            foreach (var element in list.Where(x => (x > filter)).ToList())
            {
                loops++;
            }
            timer.Stop();
            Console.WriteLine("One loop using List took: " + timer.ElapsedMilliseconds);


            loops = 0;
            timer.Reset();
            timer.Start();
            for (int i = 0; i < 5; i++)
            {
                foreach (var element in list.Where(x => (x > filter)))
                {
                    loops++;
                }
            }
            timer.Stop();
            Console.WriteLine("Five loops using Enumerable took: " + timer.ElapsedMilliseconds);

            loops = 0;
            timer.Reset();
            timer.Start();
            for (int i = 0; i < 5; i++)
            {
                foreach (var element in list.Where(x => (x > filter)).ToList())
                {
                    loops++;
                }
            }
            timer.Stop();
            Console.WriteLine("Five loops using List converted inside the foreach took: " + timer.ElapsedMilliseconds);

            loops = 0;
            timer.Reset();
            timer.Start();
            filteredList = list.Where(x => (x > filter)).ToList();
            for (int i = 0; i < 5; i++)
            {
                foreach (var element in filteredList)
                {
                    loops++;
                }
            }
            timer.Stop();
            Console.WriteLine("Five loops using List converted outside the foreach took: " + timer.ElapsedMilliseconds);
            timer.Reset();
        }
    }
}
