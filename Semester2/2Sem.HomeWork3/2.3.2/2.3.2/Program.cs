﻿using System;

namespace _2._3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTable = new HashTable(new HashFunction1());
            myTable.Add("Brian");
            myTable.Add("Christine");
            myTable.Add("Daisy");
            myTable.Add("Evan");
            myTable.Add("Jacob");
            myTable.Add("Luke");
            myTable.Add("Simon");
            myTable.ChangeHashFunction(new HashFunction2());
            Console.WriteLine(myTable.IsContain("Brian"));
            Console.WriteLine(myTable.IsContain("Christine"));
            Console.WriteLine(myTable.IsContain("Ivan"));
            Console.WriteLine(myTable.IsContain("Evan"));
            myTable.Remove("Evan");
            Console.WriteLine(myTable.IsContain("Evan"));
        }
    }
}