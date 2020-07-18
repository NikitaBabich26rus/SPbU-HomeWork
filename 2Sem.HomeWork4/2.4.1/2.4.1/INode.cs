namespace _2._4._1
{
    /// <summary>
    /// Node in an abstract syntax tree
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Expression output
        /// </summary>
        public void Print();

        /// <summary>
        /// Expression counting
        /// </summary>
        /// <returns>Result of counting</returns>
        public double Counting();
    }
}
