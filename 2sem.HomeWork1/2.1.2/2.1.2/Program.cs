
using System;

namespace _2._1._2
{
    class Program
    {
        private static int Fibonacci(int numberOfFibonacci)
        {
            int currentFibonacci1 = 0;
            int currentFibonacci2 = 1;
            for (int i = 2; i < numberOfFibonacci; i++)
            {
                int helpValue = currentFibonacci2;
                currentFibonacci2 = currentFibonacci2 + currentFibonacci1;
                currentFibonacci1 = helpValue;
            }
            if (numberOfFibonacci == 1)
            {
                return currentFibonacci1;
            }
            return currentFibonacci2;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите номер числа Фибоначчи : ");
            int numberOfFibonacci = int.Parse(Console.ReadLine());
            Console.WriteLine("Число Фибоначчи номер " + numberOfFibonacci + " : " + Fibonacci(numberOfFibonacci));
        }
    }
}
