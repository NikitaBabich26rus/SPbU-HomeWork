using System.Threading;

namespace HomeWork1
{
    /// <summary>
    /// Operation class for matrices multiplication
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// Parallel multiplication type
        /// </summary>
        /// <param name="matrixA">First matrix</param>
        /// <param name="matrixB">First matrix</param>
        /// <returns>Multiplication matrix</returns>
        public static int[,] ParallelMultiplication(Matrix matrixA, Matrix matrixB)
        {
            var matrixArrayA = matrixA.MatrixArray;
            var matrixArrayB = matrixB.MatrixArray;
            if (matrixArrayA.ColumnsCount() != matrixArrayB.RowsCount())
            {
                throw new MatrixMultiplicationException("Multiplication is not possible! The number of columns in the first matrix is ​​not equal to the number of rows in the second matrix.");
            }

            var matrixArrayC = new int[matrixArrayA.RowsCount(), matrixArrayB.ColumnsCount()];
            var threads = new Thread[3];
            var step = matrixArrayC.GetLength(0) / threads.Length;

            if (step == 0)
            {
                return SingleMultiplication(matrixA, matrixB);
            }

            for (int i = 0; i < threads.Length; i++)
            {
                var localI = i;
                threads[i] = new Thread(() =>
                {
                    var length = (localI + 1) * step;
                    if (localI == threads.Length - 1)
                    {
                        length = matrixArrayC.GetLength(0);
                    }
                    for (int strings = localI * step; strings < length; strings++)
                    {
                        for (int columns = 0; columns < matrixArrayC.GetLength(1); columns++)
                        {
                            for (int k = 0; k < matrixArrayA.GetLength(1); k++)
                            {
                                matrixArrayC[strings, columns] += matrixArrayA[strings, k] * matrixArrayB[k, columns];
                            }
                        }
                    }
                });
            }
            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            
            return matrixArrayC;
        }

        /// <summary>
        /// Single multiplication type
        /// </summary>
        /// <param name="matrixA">First matrix</param>
        /// <param name="matrixB">Second matrix</param>
        /// <returns>Multiplication matrix</returns>
        public static int[,] SingleMultiplication(Matrix matrixA, Matrix matrixB)
        {
            var matrixArrayA = matrixA.MatrixArray;
            var matrixArrayB = matrixB.MatrixArray;
            if (matrixArrayA.ColumnsCount() != matrixArrayB.RowsCount())
            {
                throw new MatrixMultiplicationException("Multiplication is not possible! The number of columns in the first matrix is ​​not equal to the number of rows in the second matrix.");
            }

            var matrixArrayC = new int[matrixArrayA.RowsCount(), matrixArrayB.ColumnsCount()];

            for (var i = 0; i < matrixArrayA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixArrayB.ColumnsCount(); j++)
                {
                    matrixArrayC[i, j] = 0;

                    for (var k = 0; k < matrixArrayA.ColumnsCount(); k++)
                    {
                        matrixArrayC[i, j] += matrixArrayA[i, k] * matrixArrayB[k, j];
                    }
                }
            }
            return matrixArrayC;
        }

        /// <summary>
        /// Get rows count
        /// </summary>
        /// <param name="matrix">Array for storing matrix</param>
        /// <returns>Rows count</returns>
        private static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }

        /// <summary>
        /// Get columns count
        /// </summary>
        /// <param name="matrix">Array for storing matrix</param>
        /// <returns>Columns count</returns>
        private static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
}
