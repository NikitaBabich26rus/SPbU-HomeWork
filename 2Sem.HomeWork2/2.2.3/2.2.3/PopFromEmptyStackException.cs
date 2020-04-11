using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    /// <summary>
    /// Exception for pop from empty stack 
    /// </summary>
    public class PopFromEmptyStackException : Exception
    {
        public PopFromEmptyStackException() { }
        public PopFromEmptyStackException(string message) : base(message) { }
        public PopFromEmptyStackException(string message, Exception inner)
        : base(message, inner) { }
        protected PopFromEmptyStackException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}