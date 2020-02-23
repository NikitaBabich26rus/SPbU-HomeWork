using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._1
{
    public class List
    {
        private class ListElement
        {
            internal int value;
            internal ListElement next;
            public ListElement(int value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }
        }
        private ListElement head;
        private int size;

        public List CreateList()
        {
            return new List();
        }
        public void Add(int value, int position)
        {    
            if (position > size + 1 || position <= 0)
            {
                return;
            }
            if (position == 1)
            {
                head = new ListElement(value, head);
                size++;
                return;
            }
            ListElement currentElement = head;
            for (int i = 1;  position != i + 1; i++)
            {
                currentElement = currentElement.next;
            }
            currentElement.next = new ListElement(value, currentElement.next);
            size++;
        }

        public void Remove(int position)
        {
            if (position <= 0 || position > size)
            {
                return;
            }
            if (position == 1)
            {
                head = head.next;
                size--;
                return;
            }

            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                if (position == i + 1)
                {
                    currentElement.next = currentElement.next.next;
                    size--;
                    return;
                }
                currentElement = currentElement.next;
            }
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        => size == 0 ? true : false;

        public int GetElement(int position)
        {
            if (position > size || position <= 0)
            {
                return -1;
            }
            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                if (position == i)
                {
                    return currentElement.value;
                }
                currentElement = currentElement.next;
            }
            return currentElement.value;
        }

        public void OutputList()
        {
            ListElement currentElement = head;
            for (int i = 1; i <= size; i++)
            {
                Console.Write(currentElement.value + " ");
                currentElement = currentElement.next;
            }
            Console.WriteLine();
        }
    }
}
