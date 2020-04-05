using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._2
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidMapException : Exception
    {
        public InvalidMapException() { }
        public InvalidMapException(string message) : base(message) { }
        public InvalidMapException(string message, Exception inner)
        : base(message, inner) { }
        protected InvalidMapException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}