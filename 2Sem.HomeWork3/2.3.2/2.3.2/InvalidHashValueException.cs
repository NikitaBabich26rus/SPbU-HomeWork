using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
    /// <summary>
    /// Exception for invalid hash value.  
    /// </summary>
    public class InvalidHashValueException : Exception
    {
        public InvalidHashValueException() { }

        public InvalidHashValueException(string message) : base(message) { }

        public InvalidHashValueException(string message, Exception inner)
        : base(message, inner) { }

        protected InvalidHashValueException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}