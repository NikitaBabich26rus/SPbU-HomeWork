using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._1
{
    /// <summary>
    /// Stack based on array
    /// </summary>
    public class ArrayStack : IStack
    {
        private int[] stack = new int[10000000];
        private int stackSize = 0;

        /// <summary>
        /// Push value to a stack.
        /// </summary>
        /// <param name="value">Value to be pushed.</param>
        public void Push(int value)
        {
            if (stackSize == 0)
            {
                stack[stackSize] = value;
            }
            stackSize++;
            stack[stackSize] = value;
        }

        /// <summary>
        /// Delete first stack Element
        /// </summary>
        /// <returns>Deleted stack Element</returns>
        public (int, bool) Pop()
        {
            if (stackSize == 0)
            {
                return (0, false);
            }

            var currentElement = stack[stackSize];
            stack[stackSize] = 0;
            stackSize--;
            return (currentElement, true);
        }

        /// <summary>
        /// Check list for emptiness
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsEmpty()
            => stackSize == 0 ? true : false;

        /// <summary>
        /// Clear stack
        /// </summary>
        public void Clear()
        {
            stackSize = 0;
            stack = new int[10000000];
        }
    }
}