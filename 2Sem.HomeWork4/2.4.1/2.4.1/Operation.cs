using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    public abstract class Operation : INode
    {
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }

        abstract public void Print();

        abstract public int Counting();

    }
}
