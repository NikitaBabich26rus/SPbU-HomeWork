using System;

namespace _2._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            // true - ListStack
            // false - ArrayStack
            Console.WriteLine(Calculator.Counting("2 5 * 3 4 * +", false));
            Console.WriteLine(Calculator.Counting("17 10 + 3 * 9 /", true));
            Console.WriteLine(Calculator.Counting("10 13 -", false));
            Console.WriteLine(Calculator.Counting("121 11 /", true));
        }     
    }
}
