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
        public override char OperationSign { get; set; } = '*';

        /// <summary>
        /// Get result of multiplication.
        /// </summary>
        /// <returns>Result.</returns>
        public override double Counting()
            => LeftChild.Counting() * RightChild.Counting();
    }
}
