using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    public class ArrayStack : IStack
    {
        private int[] stack = new int[100];
        private int stackSize = -1;

        public void Push(int value)
        {
            if (stackSize == -1)
            {
                stackSize++;
                stack[stackSize] = value;
                return;
            }
            stackSize++;
            stack[stackSize] = value;
        }

        public int Pop()
        {
            if (stackSize == -1)
            {
                throw new PopFromEmptyStackException();
            }
            var currentElement = stack[stackSize];
            stack[stackSize] = 0;
            stackSize--;
            return currentElement;
        }

        public bool IsEmpty()
            => stackSize == -1;
    }
}
