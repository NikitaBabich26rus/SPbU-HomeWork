using NUnit.Framework;
using System;
using System.Threading;

namespace HomeWork3
{
    public class MyThreadPoolTests
    {
        private MyThreadPool threadPool; 

        [SetUp]
        public void Setup()
        {
            threadPool = new MyThreadPool(8);
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
            Assert.AreEqual(8, numberOfEvaluatedTasks);
        }

        [Test]
        public void NullFunctionExceptionTest()
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
                    Interlocked.Increment(ref numberOfTasks);
                    Thread.Sleep(500);
                    return 5;
                });
            }

            Thread.Sleep(100);
            threadPool.Shutdown();

            Thread.Sleep(500);
            Assert.AreEqual(8, numberOfTasks);
        }

        [Test]
        public void ContinueWithTest()
        {
            int flag = 0;
            var task = threadPool.AddTask(() => 5);
            task.ContinueWith((value) =>
            {
                flag = value;
                return 12;
            });
            Thread.Sleep(2000);
            Assert.AreEqual(5, flag);
        }

        [Test]
        public void ContinueWithAfterShutdownTest()
        {
            var task = threadPool.AddTask(() => 5);
            threadPool.Shutdown();
            Thread.Sleep(100);
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
    }
}