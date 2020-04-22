using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    /// <summary>
    /// Exception for adding elements contained in a unique list
    /// </summary>
    public class AddContainingValueException : Exception
    {
        public AddContainingValueException() { }

        public AddContainingValueException(string message) : base(message) { }

        public AddContainingValueException(string message, Exception inner)
        : base(message, inner) { }

        protected AddContainingValueException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
