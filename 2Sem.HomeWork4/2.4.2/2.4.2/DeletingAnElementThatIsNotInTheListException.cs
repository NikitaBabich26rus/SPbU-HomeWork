using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    public class DeletingAnElementThatIsNotInTheListException : Exception
    {
        public DeletingAnElementThatIsNotInTheListException() { }
        public DeletingAnElementThatIsNotInTheListException(string message) : base(message) { }
        public DeletingAnElementThatIsNotInTheListException(string message, Exception inner)
        : base(message, inner) { }
        protected DeletingAnElementThatIsNotInTheListException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}
