using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    public class Number : INode
    {
        public int value { get; set; }

        public Number(int value)
        {
            this.value = value;
        }
        public void Print()
        {
            Console.Write(value);
        }

        public int Counting() => value;
        
    }
}
