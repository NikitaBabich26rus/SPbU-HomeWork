using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace HomeWork3
{
    /// <summary>
    /// Thread pool class.
    /// </summary>
    public class MyThreadPool
    {
        private readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private ConcurrentQueue<Action> queueTasks = new ConcurrentQueue<Action>();
        private static Object locker = new Object();
        private int numberOfThreadsCompletedWork;
        private AutoResetEvent newTaskControl = new AutoResetEvent(false);
        private AutoResetEvent shutDownControl = new AutoResetEvent(false);
        private readonly Thread[] threads;

        /// <summary>
        /// Thread pool constructor with threads creating.
        /// </summary>
        /// <param name="amountOfThreads">Amount of threads</param>
        public MyThreadPool(int amountOfThreads)
        {
            if (amountOfThreads <= 0)
            {
                throw new ArgumentException("Error: The number of threads is less than one.");
            }

            this.threads = new Thread[amountOfThreads];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    while (!cancelTokenSource.IsCancellationRequested || !queueTasks.IsEmpty)
                    {
                        if (queueTasks.TryDequeue(out Action action))
                        {
                            action.Invoke();
                        }
                        else
                        {
                            newTaskControl.WaitOne();
                            if (queueTasks.Count > 0)
                            {
                                newTaskControl.Set();
                            }
                        }
                    }
                    Interlocked.Increment(ref numberOfThreadsCompletedWork);
                    shutDownControl.Set();
                });
                threads[i].Start();
            }
        }

        /// <summary>
        /// Add new task in thread pool.
        /// </summary>
        /// <param name="function">Task`s function</param>
        /// <returns>Task</returns>
        public IMyTask<TResult> AddTask<TResult>(Func<TResult> function)
        {
            if (cancelTokenSource.IsCancellationRequested)
            {
                throw new InvalidOperationException("Thread pool is closed.");
            }
            var task = new MyTask<TResult>(function, this);
            AddActionInQueueTasks(task.Counting);
            return task;
        }

        /// <summary>
        /// Add action in action`s queue and check cancelTokenSource.
        /// </summary>
        /// <param name="action">Task action</param>
        private void AddActionInQueueTasks(Action action)
        {
            lock (locker)
            {
                if (cancelTokenSource.IsCancellationRequested)
                {
                    throw new InvalidOperationException("Thread pool is closed.");
                }
                AddAction(action);
            }
        }

        /// <summary>
        /// Add action in action`s queue.
        /// </summary>
        /// <param name="action">Task action</param>
        private void AddAction(Action action)
        {
            queueTasks.Enqueue(action);
            newTaskControl.Set();
        }

        /// <summary>
        /// Close thread pool.
        /// </summary>
        public void Shutdown()
        {
            lock (locker)
            {
                this.cancelTokenSource.Cancel();
                newTaskControl.Set();
            }
            while (this.numberOfThreadsCompletedWork != this.threads.Length)
            {
                shutDownControl.WaitOne();
                newTaskControl.Set();
            }
            //queueTasks = null;
        }

        /// <summary>
        /// My task class
        /// </summary>
        private class MyTask<TResult> : IMyTask<TResult>
        {
            private readonly MyThreadPool threadPool;
            private readonly Queue<Action> localQueue = new Queue<Action>();
            private static object locker = new object();
            private TResult taskResult;
            private Func<TResult> function;
            private Exception taskException;
            private ManualResetEvent resultSignal = new ManualResetEvent(false);

            /// <summary>
            /// Checking the task for completeness
            /// </summary>
            public bool IsCompleted { get; private set; }

            /// <summary>
            /// Get result and blocks the caller until the task is finished,
            /// and throws an exception to the caller if the task threw an exception
            /// </summary>
            public TResult Result
            {
                get
                {
                    resultSignal.WaitOne();
                    if (taskException != null)
                    {
                        throw new AggregateException(taskException);
                    }
                    return this.taskResult;
                }
            }

            /// <summary>
            /// My task constructor.
            /// </summary>
            /// <param name="function">Task function</param>
            /// <param name="threadPool">Task thread pool</param>
            protected internal MyTask(Func<TResult> function, MyThreadPool threadPool)
            {
                if (function == null)
                {
                    throw new ArgumentNullException(nameof(function));
                }
                this.threadPool = threadPool;
                this.function = function;
            }

            /// <summary>
            /// Add new task based on result of this task.
            /// </summary>
            /// <param name="func">New function</param>
            /// <returns>New task</returns>
            public IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func)
            {
                if (threadPool.cancelTokenSource.IsCancellationRequested)
                {
                    throw new InvalidOperationException("Thread pool is closed.");
                }
                var newTask = new MyTask<TNewResult>(() => func(Result), threadPool);
                lock (locker)
                {
                    if (IsCompleted)
                    {
                        return threadPool.AddTask(() => func(Result));
                    }
                    localQueue.Enqueue(newTask.Counting);
                    return newTask;
                }
            }

            /// <summary>
            /// Function counting.
            /// </summary>
            protected internal void Counting()
            {
                try
                {
                    this.taskResult = function();
                }
                catch (Exception e)
                {
                    taskException = e;
                }
                finally
                {
                    lock (locker)
                    {
                        IsCompleted = true;
                        resultSignal.Set();
                        function = null;
                        while (localQueue.Count != 0)
                        {
                            threadPool.AddAction(localQueue.Dequeue());
                        }
                    }
                }
            }
        }
    }
}