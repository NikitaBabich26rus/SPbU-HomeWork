using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._1
{
    public class Division : Operation
    {
        public override void Print()
        {
            Console.Write("(");
            LeftChild.Print();
            Console.Write("/");
            RightChild.Print();
            Console.Write(")");
        }

        public override int Counting()
            => LeftChild.Counting() / RightChild.Counting();
    }
}
