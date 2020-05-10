using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
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
