using System;

namespace _2._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.BuildTree("(/ 3 2 )");
            Console.WriteLine(tree.Counting());
        }
    }
}
