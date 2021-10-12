using System;

namespace _2.Test._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var queue = new Queue<int>();
                queue.Enqueue(3, 3);
                queue.Enqueue(5, 5);
                queue.Enqueue(4, 4);
                queue.Enqueue(1, 1);
                queue.Enqueue(6, 6);
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());
                Console.WriteLine(queue.Dequeue());
            }
            catch (DequeueFromEmptyQueueException)
            {
                Console.WriteLine("Error : Dequeue from empty queue");
            }
        }
    }
}
