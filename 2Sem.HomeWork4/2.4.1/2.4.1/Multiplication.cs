using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    /// <summary>
    /// Multiplication class
    /// </summary>
    public class Multiplication : Operation
    {
        /// <summary>
        /// Result of multiplication
        /// </summary>
        /// <returns></returns>
        public override double Counting()
            => LeftChild.Counting() * RightChild.Counting();
    }
}
