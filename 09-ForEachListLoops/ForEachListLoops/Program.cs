using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEachListLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"..\..\..\..\SampleData.txt";
            var file = System.IO.File.OpenText(filePath);
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            string line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                list1.Add(int.Parse(line));
                list2.Add(int.Parse(line));
                line = file.ReadLine();
            }

            var nLoops = 100;

            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                for (int i = 0, n = list1.Count; i < n; i++)
                    list1[i]++;

            timer.Stop();
            Console.WriteLine("Normal for block took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                list2.ForEach(element => element++);

            timer.Stop();
            Console.WriteLine("Lambda list foreach loop took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                foreach (var element in list1)
                {
                    int a = element;
                    a++;
                }
            timer.Stop();
            Console.WriteLine("Normal foreach not modifying elements inside the collection loop took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                list2.ForEach(element =>
                {
                    int a = element;
                    a++;
                });

            timer.Stop();
            Console.WriteLine("Lambda List foreach not modifying elements inside the collection loop took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                foreach (var element in list1)
                {
                    ;
                }
            timer.Stop();
            Console.WriteLine("Normal foreach any action in the loop took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int x = 0; x < nLoops; x++)
                list2.ForEach(element =>
                {
                    ;
                });

            timer.Stop();
            Console.WriteLine("Lambda List foreach any action in the loop took: " + timer.ElapsedMilliseconds);
        }
    }
}
