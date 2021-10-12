using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Test._1
{
    /// <summary>
    /// Exception for Dequeue from empty queue.
    /// </summary>
    public class DequeueFromEmptyQueueException : Exception
    {
        public DequeueFromEmptyQueueException() { }

        public DequeueFromEmptyQueueException(string message) : base(message) { }

        public DequeueFromEmptyQueueException(string message, Exception inner)
        : base(message, inner) { }

        protected DequeueFromEmptyQueueException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}