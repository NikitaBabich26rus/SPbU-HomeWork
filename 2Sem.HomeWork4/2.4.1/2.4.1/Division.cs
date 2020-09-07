using System;

namespace _2._4._1
{
    /// <summary>
    /// Division class
    /// </summary>
    public class Division : Operation
    {
        /// <summary>
        /// Division sign.
        /// </summary>
        protected override char OperationSign { get; } = '/';

        /// <summary>
        /// Division counting
        /// </summary>
        /// <returns>Result of division</returns>
        public override double Counting()
        {
            double value1 = LeftChild.Counting();
            double value2 = RightChild.Counting();
            if (value2 == 0)
            {
                throw new DivideByZeroException();
            }
            return value1 / value2;
        }
    }
}
