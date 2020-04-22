using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _2._4._1
{
    /// <summary>
    /// Class Addition
    /// </summary>
    public class Addition : Operation
    { 
        /// <summary>
        /// Output expression with addition
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
        /// Addition counting
        /// </summary>
        /// <returns>Result of addition</returns>
        public override double Counting()
            => LeftChild.Counting() + RightChild.Counting();
    }
}
