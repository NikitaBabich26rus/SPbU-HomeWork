using System;
using System.Diagnostics;

namespace Test2
{
    class Program
    {
        /// <summary>
        /// Testing run time.
        /// </summary>
        /// <param name="path">Path</param>
        static void RunningTimeTesting(string path)
        {
            var checkSum = new CheckSum();

            var stopWathSingleThreaded = new Stopwatch();
            stopWathSingleThreaded.Start();
            checkSum.SingleThreaded(path);
            stopWathSingleThreaded.Stop();

            var stopWathMultipleThreaded = new Stopwatch();
            stopWathMultipleThreaded.Start();
            checkSum.SingleThreaded(path);
            stopWathMultipleThreaded.Stop();

            Console.WriteLine("Run time the multiple threaded way: ");
            Console.WriteLine(stopWathMultipleThreaded.Elapsed);
            Console.WriteLine("Run time the single threaded way: ");
            Console.WriteLine(stopWathSingleThreaded.Elapsed);

            if (stopWathSingleThreaded.Elapsed > stopWathMultipleThreaded.Elapsed)
            {
                Console.WriteLine("Single threaded way is faster");
                return;
            }
            Console.WriteLine("Multiple threaded way is faster");
        }

        static void Main(string[] args)
        {
            RunningTimeTesting("../../../Directory");
        }
    }
}
