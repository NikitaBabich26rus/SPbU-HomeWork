namespace _2._4._1
{
    /// <summary>
    /// Subtraction's class
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Subtraction sign.
        /// </summary>
        protected override char OperationSign { get; set; } = '-';

        /// <summary>
        /// Subtraction's counting
        /// </summary>
        /// <returns>Subtraction's result</returns>
        public override double Counting()
            => LeftChild.Counting() - RightChild.Counting();
    }
}
