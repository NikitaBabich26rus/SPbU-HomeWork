using System;

namespace _2._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.buildTree("( + (* 2 3) (- 5 6))");
            Console.WriteLine(tree.outputTree());
        }
    }
}
