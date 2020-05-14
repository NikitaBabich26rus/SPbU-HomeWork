namespace _2._4._1
{
    /// <summary>
    /// Class Addition
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Addition sign.
        /// </summary>
        protected override char OperationSign { get; set; } = '+';

        /// <summary>
        /// Addition counting
        /// </summary>
        /// <returns>Result of addition</returns>
        public override double Counting()
            => LeftChild.Counting() + RightChild.Counting();
    }
}
