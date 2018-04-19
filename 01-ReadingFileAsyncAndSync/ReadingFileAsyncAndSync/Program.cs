using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFileAsyncAndSync
{
    class Program
    {
        private static async Task<string> GetFileAsync()
        {
            var path = @"..\..\..\..\SampleData.txt";
            using (var reader = File.OpenText(path))
            {
                var fileText = await reader.ReadToEndAsync();
            }
            return "OK";
        }

        private static string GetFile()
        {
            var path = @"..\..\..\..\SampleData.txt";
            using (var reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
            }
            return "OK";
        }
        static void Main(string[] args)
        {
            //int nLoops = 10000;
            int nLoops = 5;

            //Warming IO channels
            for (int i = 0; i < 2; i++)
            {
                GetFile();
                var res = GetFileAsync().Result;
            }

            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < nLoops; i++)
            {
                var res = GetFile();
            }
            timer.Stop();
            Console.WriteLine("Done by get file sync took: " + timer.ElapsedMilliseconds);

            timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < nLoops; i++)
            {
                var res = GetFileAsync().Result;
            }
            timer.Stop();
            Console.WriteLine("Done by get file Async took: " + timer.ElapsedMilliseconds);
        }
    }
}
