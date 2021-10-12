using System;

namespace _2._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // true - ListStack
            // false - ArrayStack
            Console.WriteLine(Calculator.Counting("2 5 * 3 4 * +", false).Item1);
            Console.WriteLine(Calculator.Counting("17 10 + 3 * 9 /", true).Item1);
            Console.WriteLine(Calculator.Counting("10 13 -", false).Item1);
            Console.WriteLine(Calculator.Counting("121 11 /", true).Item1);
        }
    }
}
