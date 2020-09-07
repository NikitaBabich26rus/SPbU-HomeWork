using NUnit.Framework;
using System.Diagnostics;
using System;

namespace HomeWork1
{
    public class Tests
    {
        private Matrix matrixA;
        private Matrix matrixB;

        [SetUp]
        public void Setup()
        {
            matrixA = new Matrix("./../../../MatrixA.txt");
            matrixB = new Matrix("./../../../MatrixB.txt");
        }

        [Test]
        public void CheckingSingleAndParallelMultiplicationsForCorrectness()
        {
            var matrixResult1 = Operation.ParallelMultiplication(matrixA, matrixA);
            var matrixResult2 = Operation.SingleMultiplication(matrixA, matrixA);
            bool check = true;
            for (int i = 0; i < matrixResult2.GetLength(0); i++)
            {
                for (int j = 0; j < matrixResult2.GetLength(1); j++)
                {
                    if (matrixResult1[i, j] != matrixResult2[i, j])
                    {
                        check = false;
                    }
                }
            }
            Assert.IsTrue(check);
        }
        
        [Test]
        public void CheckinggSingleAndParallelMultiplicationsWithInvalidMatrices()
        {
            Assert.Throws<MatrixMultiplicationException>(() => Operation.ParallelMultiplication(matrixA, matrixB));
            Assert.Throws<MatrixMultiplicationException>(() => Operation.SingleMultiplication(matrixA, matrixB));
        }

        [Test]
        public void CheckinggSingleAndParallelMultiplicationsWithEmptyFile()
        {
            Assert.Throws<MatrixMultiplicationException>(() => new Matrix("./../../../EmptyFile.txt"));
        }

        [Test]
        public void ComparisonOfTheSpeedSingleAndParallelMultiplications()
        {
            Stopwatch stopWatchParallelMultiplication = new Stopwatch();
            stopWatchParallelMultiplication.Start();
            var matrixResult1 = Operation.ParallelMultiplication(matrixA, matrixA);
            stopWatchParallelMultiplication.Stop();

            TimeSpan tsParallelMultiplication = stopWatchParallelMultiplication.Elapsed;

            Stopwatch stopWatchSingleMultiplication = new Stopwatch();
            stopWatchParallelMultiplication.Start();
            var matrixResult2 = Operation.SingleMultiplication(matrixA, matrixA);
            stopWatchParallelMultiplication.Stop();

            TimeSpan tsSingleMultiplication = stopWatchParallelMultiplication.Elapsed;

            Assert.IsTrue(tsParallelMultiplication.Milliseconds < tsSingleMultiplication.Milliseconds);
        }
    }
}