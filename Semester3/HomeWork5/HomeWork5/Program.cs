using System;

namespace HomeWork5
{
    class Program
    {
        /// <summary>
        /// Print info about test.
        /// </summary>
        /// <param name="info">Info about test.</param>
        static void PrintInfo(TestInfo info)
        {
            Console.WriteLine(info.Name);
            Console.WriteLine(info.Result);
            if (info.IgnoreReason != null)
            {
                Console.WriteLine(info.IgnoreReason);
            }
            Console.WriteLine(info.Time);
            Console.WriteLine();
        }

        /// <summary>
        /// Testing class with tests.
        /// </summary>
        /// <param name="file">File.</param>
        static void Testing(string file)
        {
            var tests = new MyNUnit(file);
            tests.ClassQueue.TryDequeue(out var info);
            var answer = info.ToArray();
            foreach (var item in answer)
            {
                PrintInfo(item);
            }
        }

        static void Main(string[] args)
        {
            Testing(args[0]);
        }
    }
}