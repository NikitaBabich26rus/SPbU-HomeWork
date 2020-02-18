using System;

namespace _2._1._5
{
    class Program
    {
        private static int[,] SortingOfFirstString(int[,] array, int[,] sortingArray)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (sortingArray[0, j] > sortingArray[0, j + 1])
                    {
                        (sortingArray[0, j], sortingArray[0, j + 1]) = (sortingArray[0, j + 1], sortingArray[0, j]);
                    }
                }
            }
            return sortingArray;
        }

        private static int[,] ColumnSort(int[,] array)
        {
            bool[] used = new bool[array.GetLength(1)];
            int[,] sortingArray = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sortingArray[0, i] = array[0, i];
            }
            SortingOfFirstString(array, sortingArray);

            for (int i = 0; i < sortingArray.GetLength(1); i++)
            {
                bool check = true;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (sortingArray[0, i] == array[0, j] && !used[j] && check)
                    {
                        used[j] = true;
                        for (int count = 1; count < array.GetLength(0); count++)
                        {
                            sortingArray[count, i] = array[count, j];
                        }
                        check = false;
                    }
                }
            }

            return sortingArray;
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
