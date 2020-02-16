using System;

namespace _2._1._5
{
    class Program
    {
        private static int[,] BubbleSort(int[,] array, int numberOfColumn)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (array[j, numberOfColumn] > array[j + 1, numberOfColumn])
                    {
                        (array[j, numberOfColumn], array[j + 1, numberOfColumn]) = (array[j + 1, numberOfColumn], array[j, numberOfColumn]);
                    }
                }
            }
            return array;
        }

        private static void OutputArray(int[,] array)
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
            Console.Write("Введите количество строк матрицы : ");
            int amountOfString = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы : ");
            int amountOfColumns = int.Parse(Console.ReadLine());

            int[,] array = new int[amountOfString, amountOfColumns];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 9);
                }
            }

            Console.WriteLine("Исходная матрица : ");
            OutputArray(array);

            for (int i = 0; i < array.GetLength(1); i++)
            {
                array = BubbleSort(array, i);
            }

            Console.WriteLine("Отсортированная матрица : ");
            OutputArray(array);
        }
    }
}
