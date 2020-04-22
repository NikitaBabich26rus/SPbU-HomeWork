using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    /// <summary>
    /// Operation`s class
    /// </summary>
    public abstract class Operation : INode
    {
        public char OperationSign { get; set; }
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }

        /// <summary>
        /// Expression's output
        /// </summary>
        abstract public void Print();

        /// <summary>
        /// Expression's counting
        /// </summary>
        /// <returns>Expression's result</returns>
        abstract public double Counting();

    }
}
