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
        /// <summary>
        /// Number`s value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Number`s constructor.
        /// </summary>
        /// <param name="value">Element`s value</param>
        public Number(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Value output
        /// </summary>
        public void Print() => Console.Write(Value);

        /// <summary>
        /// Return value of tree element
        /// </summary>
        /// <returns>value</returns>
        public double Counting() => Value;
        
    }
}
