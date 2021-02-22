using System;

namespace HomeWork2
{
    /// <summary>
    /// Сlass allowing to choose single threaded or multi threaded.
    /// </summary>
    public static class LazyFactory<T>
    {
        /// <summary>
        /// Create single threaded lazy
        /// </summary>
        /// <param name="supplier">Function</param>
        /// <returns>Single threaded lazy</returns>
        public static LazySingleThreaded<T> CreateSingleThreadedLazy(Func<T> supplier) => new LazySingleThreaded<T>(supplier);

        /// <summary>
        /// Creates multi threaded lazy
        /// </summary>
        /// <param name="supplier">Function</param>
        /// <returns>Multi threaded lazy</returns>
        public static LazyMultiThreaded<T> CreateMultiThreadedLazy(Func<T> supplier) => new LazyMultiThreaded<T>(supplier);
    }
}
