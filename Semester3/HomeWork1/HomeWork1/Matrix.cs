using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeWork1
{
    /// <summary>
    /// Matrix class
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Array for storing matrix
        /// </summary>
        public int[,] MatrixArray { private set; get; }

        /// <summary>
        /// Matrix constructor with file
        /// </summary>
        /// <param name="file">file whith matrix</param>
        public Matrix(string file)
        {
            var matrix = new List<string>();
            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    matrix.Add(sr.ReadLine());
                }
            }
            CreateTheArray(matrix);
        }

        /// <summary>
        /// Matrix constructor with array
        /// </summary>
        /// <param name="matrixArray">Matrix array</param>
        public Matrix(int[,] matrixArray)
        {
            this.MatrixArray = matrixArray;
        }

        /// <summary>
        /// Create MatrixArray by string list
        /// </summary>
        /// <param name="matrix">String list</param>
        private void CreateTheArray(List<string> matrix)
        {
            if (matrix.Count == 0)
            {
                throw new MatrixMultiplicationException("File is empty.");
            }
            int[] arrayForGetSize = matrix[0].Split(' ').Select(x => int.Parse(x)).ToArray();
            this.MatrixArray = new int[matrix.Count, arrayForGetSize.Length];

            for (int i = 0; i < this.MatrixArray.GetLength(0); i++)
            {
                int[] currentArray = matrix[i].Split(' ').Select(x => int.Parse(x)).ToArray();
                if (currentArray.Length != this.MatrixArray.GetLength(1))
                {
                    throw new MatrixMultiplicationException("Invalid matrix.");
                }
                for (int j = 0; j < this.MatrixArray.GetLength(1); j++)
                {
                    this.MatrixArray[i, j] = currentArray[j];
                }
            }
        }

        /// <summary>
        /// Output matrix
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.MatrixArray.GetLength(1); j++)
                {
                    Console.Write(this.MatrixArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
