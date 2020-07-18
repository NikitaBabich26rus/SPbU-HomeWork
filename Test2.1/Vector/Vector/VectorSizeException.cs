using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    /// <summary>
    /// Exception for different vector`s sizes;
    /// </summary>
    public class VectorSizeException : Exception
    {
        public VectorSizeException()
        {
        }

        public VectorSizeException(string message)
            : base(message)
        {
        }

        public VectorSizeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected VectorSizeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
