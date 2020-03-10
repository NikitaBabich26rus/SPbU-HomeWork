using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    /// <summary>
    /// Tree element
    /// </summary>
    public class Number : INode
    {
        public double value { get; set; }

        public Number(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Value output
        /// </summary>
        public void Print()
        {
            Console.Write(value);
        }

        /// <summary>
        /// Return value of tree element
        /// </summary>
        /// <returns>value</returns>
        public double Counting() => value;
        
    }
}
