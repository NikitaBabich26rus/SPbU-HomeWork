using System;

namespace _2._1._4
{
    class Program
    {

        enum Command
        {
            right,
            left,
            up,
            down
        }

        private static int[] GetTheSpiralArray(int[,] array)
        {
            int numberOfString = 0;
            int numberOfColumn = array.GetLength(1) - 1;
            int[] spiralArray = new int[array.Length];
            Command command = Command.left;
            int count = array.Length - 1;
            bool[,] used = new bool[array.GetLength(1), array.GetLength(1)];

            for (int i = 0; i < array.Length * array.Length; i++)
            {
                switch (command)
                {
                    case Command.left:
                        {
                            if (used[numberOfString, numberOfColumn])
                            {
                                numberOfColumn++;
                                numberOfString++;
                                command = Command.down;
                                break;
                            }
                            spiralArray[count] = array[numberOfString, numberOfColumn];
                            used[numberOfString, numberOfColumn] = true;
                            count--;
                            if ((numberOfString == array.GetLength(0) / 2 + 1) && (numberOfColumn == array.GetLength(0) / 2 + 1))
                            {
                                return spiralArray;
                            }
                            if (numberOfColumn == 0)
                            {
                                numberOfString++;
                                command = Command.down;
                                break;
                            }
                            numberOfColumn--;
                            break;
                        }
                    case Command.down:
                        {
                            if (used[numberOfString, numberOfColumn])
                            {
                                numberOfString--;
                                numberOfColumn++;
                                command = Command.right;
                                break;
                            }
                            spiralArray[count] = array[numberOfString, numberOfColumn];
                            used[numberOfString, numberOfColumn] = true;
                            count--;
                            if (numberOfString == array.GetLength(0) - 1)
                            {
                                numberOfColumn++;
                                command = Command.right;
                                break;
                            }
                            numberOfString++;
                            break;
                        }
                    case Command.right:
                        {
                            if (used[numberOfString, numberOfColumn])
                            {
                                numberOfColumn--;
                                numberOfString--;
                                command = Command.up;
                                break;
                            }
                            spiralArray[count] = array[numberOfString, numberOfColumn];
                            used[numberOfString, numberOfColumn] = true;
                            count--;
                            if (numberOfColumn == array.GetLength(0) - 1)
                            {
                                numberOfString--;
                                command = Command.up;
                                break;
                            }
                            numberOfColumn++;
                            break;
                        }
                    case Command.up:
                        {
                            if (used[numberOfString, numberOfColumn])
                            {
                                numberOfColumn--;
                                numberOfString++;
                                command = Command.left;
                                break;
                            }
                            spiralArray[count] = array[numberOfString, numberOfColumn];
                            used[numberOfString, numberOfColumn] = true;
                            count--;
                            numberOfString--;
                            break;
                        }

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

            int[] spiralArray = GetTheSpiralArray(array);
            Console.WriteLine("Массив заданный по спирали : ");
            
            for (int i = 0; i < spiralArray.Length; i++)
            {
                Console.Write(spiralArray[i] + "  ");
            }
        }
    }
}
