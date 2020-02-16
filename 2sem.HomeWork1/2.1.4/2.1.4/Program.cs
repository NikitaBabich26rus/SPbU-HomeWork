using System;

namespace _2._1._4
{
    class Program
    {
        private static int GetElementOfArray(int[,] array, ref int numberOfString, ref int numberOfColumn)
        {
            if (numberOfColumn == 0 && numberOfString != 0)
            {
                numberOfString--;
                numberOfColumn = array.GetLength(0) - 1;
                return array[numberOfString, numberOfColumn];
            }
            numberOfColumn--;
            return array[numberOfString, numberOfColumn];
        }

        private static int[,] GetTheSpiralArray(int[,] array)
        {
            int[,] spiralArray = new int[array.GetLength(0), array.GetLength(0)];

            int numberOfString = array.GetLength(0) - 1;
            int numberOfColumn = array.GetLength(0);
            int mid = array.GetLength(0) / 2 + 1;

            for (int count = 1; count <= mid; count++)
            {
                for (int j = count - 1; j < array.GetLength(0) - count + 1; j++)
                {
                    spiralArray[count - 1, j] = GetElementOfArray(array, ref numberOfString, ref numberOfColumn);
                }

                for (int j = count; j < array.GetLength(0) - count + 1; j++)
                {
                    spiralArray[j, array.GetLength(0) - count] = GetElementOfArray(array, ref numberOfString, ref numberOfColumn);
                }

                for (int j = array.GetLength(0) - count - 1; j >= count - 1; --j)
                {
                    spiralArray[array.GetLength(0) - count, j] = GetElementOfArray(array, ref numberOfString, ref numberOfColumn);
                }

                for (int j = array.GetLength(0) - count - 1; j >= count; j--)
                {
                    spiralArray[j, count - 1] = GetElementOfArray(array, ref numberOfString, ref numberOfColumn);
                }
            }
            return spiralArray;
        }

        private static void OutputArray (int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите размер матрицы : ");
            int size = int.Parse(Console.ReadLine());

            int[,] array = new int[size, size];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 9);
                }
            }

            Console.WriteLine("Исходный массив : ");
            OutputArray(array);
            Console.WriteLine();

            int[,] spiralArray = GetTheSpiralArray(array);
            Console.WriteLine("Массив заданный по спирали : ");
            OutputArray(spiralArray);
        }
    }
}
