using System;

namespace _2._4._1
{
    /// <summary>
    /// Operation`s class
    /// </summary>
    public abstract class Operation : INode
    {
        /// <summary>
        /// Mathematical operation sign.
        /// </summary>
        protected virtual char OperationSign { get; set; }

        /// <summary>
        /// Left child of the leaf tree.
        /// </summary>
        public INode LeftChild { get; set; }

        /// <summary>
        /// Right child of the leaf tree.
        /// </summary>
        public INode RightChild { get; set; }

        /// <summary>
        /// Output expression
        /// </summary>
        public void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write(OperationSign);
            RightChild.Print();
            Console.Write(")");
        }

        /// <summary>
        /// Expression's counting
        /// </summary>
        /// <returns>Expression's result</returns>
        abstract public double Counting();
    }
}
