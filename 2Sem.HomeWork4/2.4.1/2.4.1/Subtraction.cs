using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    /// <summary>
    /// Subtraction's class
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Subtraction's output
        /// </summary>
        public override void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write(OperationSign);
            RightChild.Print();
            Console.Write(")");
        }

        /// <summary>
        /// Subtraction's counting
        /// </summary>
        /// <returns>Subtraction's result</returns>
        public override double Counting()
            => LeftChild.Counting() - RightChild.Counting();
    }
}
