using System;

namespace _2._1._1
{
    class Program
    {
        private static int Factorial(int factorialNumber)
        {
            int rezult = 1;
            for (int i = 1; i < factorialNumber; i++)
            {
                int currentValue = (i + 1) * rezult;
                rezult = currentValue;
            }
            return rezult;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число : ");
            int factorialNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Факториал числа " + factorialNumber + " : " + Factorial(factorialNumber));
        }
    }
}
