using NUnit.Framework;
using System.Threading;
using System;

namespace HomeWork2
{
    public class LazyMultiThreadedTests
    {
        private LazyMultiThreaded<int> lazyMultiThreaded;
        private int result;
        private Thread[] threads;

        [SetUp]
        public void Setup()
        {
            lazyMultiThreaded = LazyFactory<int>.CreateMultiThreadedLazy(() => 
            {
                for (int i = 0; i < 100000; i++)
                {
                    result++;
                }
                return result;
            });

            threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(() => lazyMultiThreaded.Get());
            }
        }

        [Test]
        public void TestForCorrectMultiThreading()
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            Assert.AreEqual(500000, result);
        }

        [Test]
        public void NullFunctionTesting()
        {
            Assert.Throws<ArgumentNullException> (() => LazyFactory<int>.CreateMultiThreadedLazy(null));
        }
    }
}