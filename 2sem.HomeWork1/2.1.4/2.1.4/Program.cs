using System;

namespace _2._1._4
{
    class Program
    {

        enum Command
        {
            Right,
            Left,
            Up,
            Down
        }

        private static int[] GetTheSpiralArray(int[,] array)
        {
            int numberOfString = array.GetLength(1) / 2;
            int numberOfColumn = array.GetLength(1) / 2;
            int[] spiralArray = new int[array.Length];
            int count = 0;
            spiralArray[count] = array[numberOfString, numberOfColumn];
            var iStep = 1;
            var jStep = 1;

            for (int i = 1; i <= array.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (count < array.Length - 1)
                    {
                        count++;
                        numberOfColumn += jStep;
                        spiralArray[count] = array[numberOfString, numberOfColumn];
                    }
                }

                for (int j = 0; j < i; j++)
                {
                    if (count < array.Length - 1)
                    {
                        count++;
                        numberOfString += iStep;
                        spiralArray[count] = array[numberOfString, numberOfColumn];
                    }
                }

                jStep = -jStep;
                iStep = -iStep;
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

        private static int[,] CreateArray(int size)
        {
            int[,] array = new int[size, size];
            var rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 9);
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите размер матрицы : ");
            int size = int.Parse(Console.ReadLine());
            int[,] array = CreateArray(size);

            Console.WriteLine("Исходный массив : ");
            OutputArray(array);
            Console.WriteLine();

            int[] spiralArray = GetTheSpiralArray(array);
            Console.WriteLine("Массив заданный по спирали : ");
            
            for (int i = 0; i < spiralArray.Length; i++)
            {
                Console.Write(spiralArray[i] + "  ");
            }
        }
    }
}
