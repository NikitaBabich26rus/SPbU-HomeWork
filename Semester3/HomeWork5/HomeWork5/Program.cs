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
            Console.WriteLine($"Test name: {info.Name}");
            Console.WriteLine($"Result: {info.Result}");
            if (info.IgnoreReason != null)
            {
                Console.WriteLine($"Ignore reason: {info.IgnoreReason}");
            }
            Console.WriteLine($"Time: {info.Time}");
            Console.WriteLine();
        }

        /// <summary>
        /// Testing classes with tests.
        /// </summary>
        /// <param name="file">File.</param>
        static void Testing(string file)
        {
            var tests = new MyNUnit(file);
            while (!tests.ClassQueue.IsEmpty)
            {
                tests.ClassQueue.TryDequeue(out var info);
                var answer = info.ToArray();
                foreach (var item in answer)
                {
                    PrintInfo(item);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Testing(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}