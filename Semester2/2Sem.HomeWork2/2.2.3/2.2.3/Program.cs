using System;

namespace _2._2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var calculatorWithListStack = new Calculator(new ListStack());
                Console.WriteLine(calculatorWithListStack.Counting("4 5 +"));
                Console.WriteLine(calculatorWithListStack.Counting("17 10 + 3 * 9 /"));
                var calculatorWithArrayStack = new Calculator(new ArrayStack());
                Console.WriteLine(calculatorWithArrayStack.Counting("10 13 -"));
                Console.WriteLine(calculatorWithArrayStack.Counting("121 11 /"));
            }
            catch(PopFromEmptyStackException)
            {
                Console.WriteLine("Error : invalid expression.");
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Error : division by zero.");
            }
        }     
    }
}
