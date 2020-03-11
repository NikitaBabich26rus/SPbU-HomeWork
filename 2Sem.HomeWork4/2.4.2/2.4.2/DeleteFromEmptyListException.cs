using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    class DeleteFromEmptyListException : Exception
    {
        public DeleteFromEmptyListException() { }
        public DeleteFromEmptyListException(string message) : base(message) { }
        public DeleteFromEmptyListException(string message, Exception inner)
        : base(message, inner) { }
        protected DeleteFromEmptyListException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
