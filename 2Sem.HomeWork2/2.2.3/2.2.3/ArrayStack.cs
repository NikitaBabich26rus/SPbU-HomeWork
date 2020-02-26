using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    public class ArrayStack : IStack
    {
        private int[] stack = new int[100];
        private int stackSize = 0;

        public void Push(int value)
        {
            if (stackSize == 0)
            {
                stack[stackSize] = value;
            }
            stackSize++;
            stack[stackSize] = value;
        }

        public int Pop()
        {
            var currentElement = stack[stackSize];
            stack[stackSize] = 0;
            stackSize--;
            return currentElement;
        }

        public bool IsEmpty()
            => stackSize == 0 ? true : false;
    }
}
