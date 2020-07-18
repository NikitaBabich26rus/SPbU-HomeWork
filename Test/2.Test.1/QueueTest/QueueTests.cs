using NUnit.Framework;

namespace _2.Test._1
{
    public class Tests
    {
        Queue<int> queue;
        [SetUp]
        public void Setup()
        {
            queue = new Queue<int>();
        }

        [Test]
        public void EnqueueAndDequeueTest()
        {
            queue.Enqueue(3, 3);
            queue.Enqueue(5, 5);
            queue.Enqueue(4, 4);
            queue.Enqueue(1, 1);
            queue.Enqueue(6, 6);
            Assert.AreEqual(queue.Dequeue(), 6);
            Assert.AreEqual(queue.Dequeue(), 5);
            Assert.AreEqual(queue.Dequeue(), 4);
            Assert.AreEqual(queue.Dequeue(), 3);
            Assert.AreEqual(queue.Dequeue(), 1);
        }
    }
}