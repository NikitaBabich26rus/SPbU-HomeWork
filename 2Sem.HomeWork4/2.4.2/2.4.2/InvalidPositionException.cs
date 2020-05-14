using System;

namespace _2._4._2
{
    /// <summary>
    /// Exception for an erroneously specified element position in the list.
    /// </summary>
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException()
        {
        }

        public InvalidPositionException(string message)
            : base(message)
        {
        }

        public InvalidPositionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidPositionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
