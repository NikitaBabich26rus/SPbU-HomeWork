namespace _2._4._1
{
    /// <summary>
    /// Multiplication class
    /// </summary>
    public class Multiplication : Operation
    {
        /// <summary>
        /// Multiplication sign.
        /// </summary>
        protected override char OperationSign { get; set; } = '*';

        /// <summary>
        /// Get result of multiplication.
        /// </summary>
        /// <returns>Result.</returns>
        public override double Counting()
            => LeftChild.Counting() * RightChild.Counting();
    }
}
