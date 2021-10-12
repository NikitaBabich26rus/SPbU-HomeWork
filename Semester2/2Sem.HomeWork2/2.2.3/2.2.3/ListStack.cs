﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._3
{
    public class ListStack : IStack
    {
        private class StackElement
        {
            public int value;
            public StackElement next;
            public StackElement(int value, StackElement next)
            {
                this.value = value;
                this.next = next;
            }
        }

        private StackElement head = null;

        public void Push (int value)
        {
            head = new StackElement(value, head);
        }

        public int Pop()
        {
            if (head == null)
            {
                throw new PopFromEmptyStackException();
            }
            var currentElement = head;
            head = head.next;
            return currentElement.value;
        }

        public bool IsEmpty()
            => head == null;
    }
}
