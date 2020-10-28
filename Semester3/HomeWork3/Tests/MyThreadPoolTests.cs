using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HomeWork3
{
    public class MyThreadPoolTests
    {
        private MyThreadPool threadPool;
        private int numberOfThreads = Environment.ProcessorCount;
        private ManualResetEvent manualResetEvent;
        private ConcurrentQueue<int> results;
        private Thread[] threads;

        [SetUp]
        public void Setup()
        {
            threadPool = new MyThreadPool(numberOfThreads);
            manualResetEvent = new ManualResetEvent(false);
            results = new ConcurrentQueue<int>();
            threads = new Thread[numberOfThreads];
        }

        [Test]
        public void CheckingTheNumberOfThreadsTest()
        {
            int numberOfEvaluatedTasks = 0;
            for (int i = 0; i < 20; i++)
            {
                threadPool.AddTask(() =>
                {
                    Interlocked.Increment(ref numberOfEvaluatedTasks);
                    Thread.Sleep(3000);
                    return 0;
                });
            }

            Thread.Sleep(500);
            Assert.AreEqual(Environment.ProcessorCount, numberOfEvaluatedTasks);
        }

        [Test]
        public void CreateThreadPoolWithIncorrectCountThreadsExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => new MyThreadPool(-1));
        }

        [Test]
        public void AddingTaskAfterShutdown()
        {
            threadPool.Shutdown();
            Assert.Throws<InvalidOperationException>(() => threadPool.AddTask(() => 5));
        }

        [Test]
        public void AfterShutdownTasksAreAllowedToFinalizeTest()
        {
            int numberOfTasks = 0;

            for (int i = 0; i < 16; i++)
            {
                threadPool.AddTask(() =>
                {
                    Thread.Sleep(500);
                    Interlocked.Increment(ref numberOfTasks);
                    return 5;
                });
            }

            Thread.Sleep(100);
            threadPool.Shutdown();

            Thread.Sleep(500);
            Assert.AreEqual(16, numberOfTasks);
        }

        [Test]
        public void ContinueWithTest()
        {
            int flag = 0;
            var task = threadPool.AddTask(() => 5);
            Thread.Sleep(200);
            _ = task.ContinueWith((value) =>
            {
                flag = value;
                return 12;
            }).Result;
            Assert.AreEqual(5, flag);
        }

        [Test]
        public void ContinueWithAfterShutdownTest()
        {
            var task = threadPool.AddTask(() => 5);
            threadPool.Shutdown();
            Thread.Sleep(200);
            Assert.Throws<InvalidOperationException>(() => task.ContinueWith((value) => 12));
        }

        [Test]
        public void ContinueWithBeforeTheEndOfTheTask()
        {
            int flag = 0;
            var task = threadPool.AddTask(() =>
            {
                Thread.Sleep(300);
                return 5;
            });
            task.ContinueWith((value) =>
            {
                flag = value;
                return 11;
            });
            Thread.Sleep(600);
            Assert.AreEqual(5, flag);
        }

        [Test]
        public void GetTheResultAtTheSameTimeTest()
        {
            var task = threadPool.AddTask(() =>
            {
                manualResetEvent.WaitOne();
                return 5;
            });
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(() => results.Enqueue(task.Result));
                threads[i].Start();
            }
            manualResetEvent.Set();
            foreach (var thread in threads)
            {
                if (!thread.Join(200))
                {
                    Assert.Fail("Deadlock");
                }
            }
            Assert.AreEqual(numberOfThreads, results.Count);
            foreach (var result in results)
            {
                Assert.AreEqual(5, result);
            }
        }

        [Test]
        [Repeat(100)]
        public void ContinueWithStartSimultaneouslyTest()
        {
            var task = threadPool.AddTask(() =>
            {
                manualResetEvent.WaitOne();
                Thread.Sleep(2);
                return 5;
            });
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    manualResetEvent.Set();
                    results.Enqueue(task.ContinueWith(x => x * 2).Result);
                });
            }
            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                if (!thread.Join(200))
                {
                    Assert.Fail("Deadlock");
                }
            }
            foreach (var result in results)
            {
                Assert.AreEqual(10, result);
            }
            Assert.AreEqual(numberOfThreads, results.Count);
        }

        [Test]
        [Repeat(100)]
        public void GetResultAndShutdownTest()
        {
            for (var i = 0; i < numberOfThreads; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    try
                    {
                        manualResetEvent.WaitOne();
                        results.Enqueue(threadPool.AddTask(() => 1).Result);
                    }
                    catch (InvalidOperationException) { }
                });
                threads[i].Start();
            }
            var threadWithShutdown = new Thread(() =>
            {
                manualResetEvent.WaitOne();
                threadPool.Shutdown();
            });
            threadWithShutdown.Start();
            manualResetEvent.Set();
            threadWithShutdown.Join();
            foreach (var thread in threads)
            {
                if (!thread.Join(200))
                {
                    Assert.Fail("Deadlock");
                }
            }
        }
    }
}