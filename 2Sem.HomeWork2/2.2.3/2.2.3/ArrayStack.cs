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
            stack[stackSize] = value;
            stackSize++;
        }

        public int Pop()
        {
            var currentElement = stack[stackSize - 1];
            stack[stackSize - 1] = 0;
            stackSize--;
            return currentElement;
        }

        public bool IsEmpty()
            => stackSize == 0 ? true : false;
    }
}
