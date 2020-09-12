using System.Diagnostics;
using System;

namespace HomeWork1
{
    class Program
    {
        /// <summary>
        /// Creating a matrix filled with units.
        /// </summary>
        /// <param name="amountOfStrings">Amount of strings in matrix</param>
        /// <param name="amountOfColumns">Amount of columns in matrix</param>
        /// <returns>Matrix</returns>
        static int[,] CreateMatrixOfUnits(int amountOfStrings, int amountOfColumns)
        {
            var matrix = new int[amountOfStrings, amountOfColumns];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 1;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Speed comparison of parralel multiplication and single multiplication.
        /// </summary>
        /// <param name="size">Size of square matrix</param>
        static void TestingMatrixMultiplicationByTime(int size)
        {
            Console.WriteLine($"Testing matrix multiplication with dimensions {size} by {size} :");
            Console.WriteLine();

            var stopWatchParallelMultiplication = new Stopwatch();
            stopWatchParallelMultiplication.Start();
            var matrixResult1 = Operation.ParallelMultiplication(new Matrix(CreateMatrixOfUnits(size, size)), new Matrix(CreateMatrixOfUnits(size, size)));
            stopWatchParallelMultiplication.Stop();
            var ts1 = stopWatchParallelMultiplication.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);
            Console.WriteLine("RunTime of parallel multiplication : " + elapsedTime);


            var stopWatchSingleMultiplication = new Stopwatch();
            stopWatchSingleMultiplication.Start();
            var matrixResult2 = Operation.SingleMultiplication(new Matrix(CreateMatrixOfUnits(size, size)), new Matrix(CreateMatrixOfUnits(size, size)));
            stopWatchSingleMultiplication.Stop();
            var ts2 = stopWatchSingleMultiplication.Elapsed;
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);
            Console.WriteLine("RunTime of single multiplication : " + elapsedTime2);
        }

        static void Main(string[] args)
        {
            TestingMatrixMultiplicationByTime(10);
            Console.WriteLine();
            TestingMatrixMultiplicationByTime(100);
            Console.WriteLine();
            TestingMatrixMultiplicationByTime(1000);
        }
    }
}
