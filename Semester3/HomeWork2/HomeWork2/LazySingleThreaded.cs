using System;

namespace HomeWork2
{
    /// <summary>
    /// Single threaded lazy.
    /// </summary>
    public class LazySingleThreaded<T> : ILazy<T>
    {
        private T value;
        private Func<T> supplier;
        private bool isCounted = false;

        /// <summary>
        /// Single threaded lazy`s constructor.
        /// </summary>
        /// <param name="supplier">Function</param>
        public LazySingleThreaded(Func<T> supplier)
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
                return this.value;
            }
            isCounted = true;
            this.value = this.supplier();
            return this.value;
        }
    }
}
