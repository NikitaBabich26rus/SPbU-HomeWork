using System;

namespace HomeWork2
{
    /// <summary>
    /// Multi threaded lazy.
    /// </summary>
    public class LazyMultiThreaded<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T result;
        private volatile bool isCounted = false;
        private object locker = new object();

        /// <summary>
        /// Multi threaded lazy`s constructor.
        /// </summary>
        /// <param name="supplier">Function</param>
        public LazyMultiThreaded(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
            this.supplier = supplier;
        }

        /// <summary>
        /// Get function`s result.
        /// </summary>
        /// <returns>Result</returns>
        public T Get()
        {
            if (isCounted)
            {
                return this.result;
            }
            lock (this.locker)
            {
                if (isCounted)
                {
                    return this.result;
                }
                this.result = this.supplier();
                this.supplier = null;
                isCounted = true;
                return this.result;
            }
        }
    }
}
