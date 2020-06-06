using System;

namespace _2._9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericSet<int> set = new GenericSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            Console.WriteLine(set.Contains(2));
            Console.WriteLine(set.Contains(3));
            set.Remove(3);
            set.Remove(2);
            Console.WriteLine(set.Contains(1));
            set.Remove(1);
            Console.WriteLine(set.Contains(3));
            Console.WriteLine(set.Contains(2));
            Console.WriteLine(set.Contains(1));
        }
    }
}
