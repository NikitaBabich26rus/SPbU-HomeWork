using System;

namespace _2._1._3
{
    class Program
    {
        private static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            return array;
        }
        private static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива : ");
            int sizeOfArray = int.Parse(Console.ReadLine());
            int[] array = new int[sizeOfArray];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите " + (i + 1) + " элемент массива : ");
                array[i] = int.Parse(Console.ReadLine());
            }
            array = BubbleSort(array);
            Console.Write("Отсортированный массив : ");
            OutputArray(array);
        }
    }
}
