using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace FG.ServiceFabric.MemoryLeak.LoadTester
{
    class Program
    {
        private static readonly string[] Animation = { "-", "\\", "|", "/" };

        static void Main(string[] args)
        {


            if (args.Length != 1)
            {
                Console.WriteLine("Provide an integer number of jobs to generate.");
            }

            Console.Write("Initializing...");

            var numberOfTests = int.Parse(args[0]);
            var queue = new ConcurrentQueue<Job>(Enumerable.Range(1, int.Parse(args[0])).Select(i => new Job(i)));
            var workers = Enumerable.Range(1, 100).Select(i => new Worker(queue));

            Console.Write("...starting to do some work");

            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;

            var tasks = workers.Select(w => w.StartAsync()).ToArray();

            var animationIndex = 0;
            while (tasks.Any(task => !task.IsCompleted))
            {
                var percentComplete = (1 - ((decimal)queue.Count) / ((decimal)numberOfTests)) * 100.0m;
                System.Console.CursorLeft = cursorLeft;
                System.Console.CursorTop = cursorTop;

                System.Console.Write($"[{Animation[animationIndex]}] {percentComplete}% complete");

                animationIndex = (animationIndex + 1) % Animation.Length;
                Task.Delay(500).GetAwaiter().GetResult();
            }

            Console.WriteLine();
            Console.WriteLine("DONE!");

        }
    }
}
