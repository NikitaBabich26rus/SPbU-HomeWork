using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    public interface INode
    {
        /// <summary>
        /// Expression output
        /// </summary>
        public void Print();

        /// <summary>
        /// Expression counting
        /// </summary>
        /// <returns>Result of counting</returns>
        public double Counting();

    }
}
