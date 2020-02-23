using System;

namespace _2._1._5
{
    class Program
    {
        private static int[,] ColumnSort(int[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[0, j] > array[0, j + 1])
                    {
                        for (int k = 0; k < array.GetLength(0); k++)
                        {
                            (array[k, j], array[k, j + 1]) = (array[k, j + 1], array[k, j]);
                        }
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
            var rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 9);
                }
            }

            Console.WriteLine("Исходная матрица : ");
            OutputArray(array);

            int[,] sortingArray = ColumnSort(array);
            Console.WriteLine("Отсортированная матрица : ");
            OutputArray(sortingArray);
        }
    }
}
