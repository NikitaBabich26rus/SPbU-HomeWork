
namespace HomeWork2
{
    /// <summary>
    /// Lazy interface
    /// </summary>
    public interface ILazy<T>
    {
        /// <summary>
        /// Get result of counting.
        /// </summary>
        /// <returns>Result</returns>
        public T Get();
    }
}
