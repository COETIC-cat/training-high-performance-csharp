using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTests
{
    class Program
    {
        static void Main(string[] args)
        {

            //In this sample we're going to create two dictionaries:
            // - One inserting the elements directly in the dictionary
            // - Another loading all elements in a list, sorting the list and adding ONLY unique elements in the dictionary

            var filePath = @"..\..\..\..\SampleData.txt";
            var file = System.IO.File.OpenText(filePath);
            Dictionary<int, object> dic1 = new Dictionary<int, object>();
            Dictionary<int, object> dic2 = new Dictionary<int, object>();
            List<int> list = new List<int>();

            // Start loading the dictionary directly
            var timer = System.Diagnostics.Stopwatch.StartNew();
            string line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                dic1[int.Parse(line)] = null;
                line = file.ReadLine();
            }
            timer.Stop();
            Console.WriteLine("Inserting directly to a dictionary took: " + timer.ElapsedMilliseconds);
            file.Close();

            file = System.IO.File.OpenText(filePath);

            // Start loading the list with any sort
            timer = System.Diagnostics.Stopwatch.StartNew();
            line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                list.Add(int.Parse(line));
                line = file.ReadLine();
            }
            // Start only once (log2 cost)
            list.Sort();

            // Iterate the sorted list only once controlling the repeated elements
            // So ONLY UNIQUE ELEMENTS will be inserted in the dictionary
            int lastInserted = 0;
            for (int i = 0, max = list.Count; i < max; i++)
            {
                if ((i == 0) || (lastInserted != list[i]))
                {
                    dic2.Add(list[i], null);
                    lastInserted = list[i];
                }
            }

            timer.Stop();
            Console.WriteLine("Inserting in a dictionary from sorted list took: " + timer.ElapsedMilliseconds);
            file.Close();
            list.Clear();
            dic1.Clear();
            dic2.Clear();

            // In this sample we're going to create a HashSet and a List with unique elements
            HashSet<int> hashSet1 = new HashSet<int>();
            List<int> plainListAux = new List<int>();
            file = System.IO.File.OpenText(filePath);

            timer = System.Diagnostics.Stopwatch.StartNew();
            
            // Inserting all elements directly in a HashSet
            line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                hashSet1.Add(int.Parse(line));
                line = file.ReadLine();
            }
            timer.Stop();
            Console.WriteLine("To load the full HashSet directly from a file took: " + timer.ElapsedMilliseconds);
            file.Close();

            file = System.IO.File.OpenText(filePath);

            // Start loading the list with any sort
            timer = System.Diagnostics.Stopwatch.StartNew();
            while ((!string.IsNullOrEmpty(line = file.ReadLine())))
            {
                plainListAux.Add(int.Parse(line));
            }
            // Hash set constructor has its own method to load the data from a List without any sort.
            // Based on this test, is slower to sort the elements previously

            //uniqueSortedListAux.Distinct().ToList(); throws an out of memory exception.

            HashSet<int> hashSet2 = new HashSet<int>(plainListAux);            
            //Uncomment the next block to test the load of a HashSet from a sorted list using the constructor
            //this is slower than to load directly from unsorted list
            //plainListAux.Sort();
            //HashSet<int> hashSet2 = new HashSet<int>(plainListAux);

            //Uncomment the next block to test the load of a HashSet from a sorted list using the constructor
            //plainListAux.Sort();
            //HashSet<int> hashSet2 = new HashSet<int>();
            ///* We add only the unique values in the HashSet. To remove the duplicates in the
            //original list is not a good idea, removing elements in the middle in a large list is expensive */
            //int element = 0;
            //for (int i = 0, max = plainListAux.Count; i < max; i++)
            //{
            //    if ((i == 0) || (element != plainListAux[i]))
            //    {
            //        hashSet2.Add(plainListAux[i]);
            //        element = plainListAux[i];
            //    }
            //}
            
            timer.Stop();
            Console.WriteLine("Creating a HashSet from an UNsorted list took: " + timer.ElapsedMilliseconds);
            file.Close();
            list.Clear();
            hashSet1.Clear();
            hashSet2.Clear();
            plainListAux.Clear();

            //We create a sorted inserting the elements directly
            SortedSet<int> sortedSet1 = new SortedSet<int>();
            file = System.IO.File.OpenText(filePath);

            timer = System.Diagnostics.Stopwatch.StartNew();
            line = file.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                sortedSet1.Add(int.Parse(line));
                line = file.ReadLine();
            }
            timer.Stop();
            Console.WriteLine("Creating a SortedSet took: " + timer.ElapsedMilliseconds);
            file.Close();
            sortedSet1.Clear();            
        }
    }
}
