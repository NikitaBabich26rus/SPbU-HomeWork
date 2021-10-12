using System;
using System.Diagnostics;

namespace Test4
{
    class Program
    {

        /// <summary>
        /// Speed comparison of multi threaded and single threaded qsort.
        /// </summary>
        static void TestingQsortByTime(int[] array)
        {
            var qsort = new QSort();

            var stopWatchParallelQsort = new Stopwatch();
            stopWatchParallelQsort.Start();
            qsort.MultiThreadedQuickSort(array);
            stopWatchParallelQsort.Stop();
            var ts1 = stopWatchParallelQsort.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);
            Console.WriteLine("RunTime of parallel qsort : " + elapsedTime);


            var stopWatchSingleQsort = new Stopwatch();
            stopWatchSingleQsort.Start();
            qsort.SingleThreadedQuickSort(array);
            stopWatchSingleQsort.Stop();
            var ts2 = stopWatchSingleQsort.Elapsed;
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);
            Console.WriteLine("RunTime of single qsort : " + elapsedTime2);
        }

        static void Main(string[] args)
        {
            var array = new int[10000];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = i;
            }

            TestingQsortByTime(array);
        }
    }
}
