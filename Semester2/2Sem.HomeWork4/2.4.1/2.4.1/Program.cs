﻿using System;
using System.Data;

namespace _2._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tree = new Tree();
                tree.BuildTree("(/ 3 2)");
                Console.WriteLine(tree.Counting());
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Invalide expression : Divide by zero");
            }
            catch(InvalidExpressionException)
            {
                Console.WriteLine("Invalide expression");
            }
        }
    }
}
