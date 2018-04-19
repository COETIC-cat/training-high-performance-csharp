using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancellingTasks
{
    class Program
    {
        static async Task DoSomethingAsync(CancellationToken c)
        {
            await Task.Delay(2000);
            if (!c.IsCancellationRequested)
                Console.WriteLine("Reached!!!");
        }

        static async Task DoSomethingAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Reached!!!");
        }


        // This main does not cancel the parallel task properly
        static void Main(string[] args)
        {
            Task[] array = new Task[1];
            array[0] = DoSomethingAsync();
            Task.WaitAll(array, 1000);
            Console.WriteLine("Main thread almost finished, pres any key");

            Console.ReadKey();
        }

        // This main cancels the parallel task properly

        //static void Main(string[] args)
        //{
        //    var cancelationSource = new CancellationTokenSource();
        //    var someLongWork = DoSomethingAsync(cancelationSource.Token);
        //    var delay = Task.Delay(1000);
        //    var completed = Task.WhenAny(someLongWork, delay);
        //    if (completed.Result == delay) // main  method can't be async, so we use .Result
        //        cancelationSource.Cancel();

        //    Console.WriteLine("Main thread almost finished, pres any key");

        //    Console.ReadKey();
        //}

        // This main also cancels the parallel task properly
        //static void Main(string[] args)
        //{
        //    var cancelationSource = new CancellationTokenSource(1000);
        //    var someLongWork = DoSomethingAsync(cancelationSource.Token);

        //    Task.WaitAll(someLongWork);

        //    Console.WriteLine("Main thread almost finished, pres any key");
        //    Console.ReadKey();
        //}

        // This main seems that cancels properly, but it doesn't
        // because the main thread finishes before than the child task
        // but the task is NOT properly cancelled as it seems!!!
        // This is a WRONG TEST CASE
        //static void Main(string[] args)
        //{
        //    Task[] array = new Task[1];
        //    array[0] = DoSomethingAsync();
        //    Task.WaitAll(array, 1000);
        //    Console.WriteLine("Main thread finished, pres any key");
        //    // Uncomment this line to proof that this method does not work as it seems
        //    //Console.ReadKey();
        //}
    }
}
