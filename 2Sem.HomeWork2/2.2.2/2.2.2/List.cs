using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._2
{
    public class List
    {
        private class ListElement
        {
            public ListElement(string value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public string value;
            public ListElement next;
        }

        private ListElement head;

        private int sizeOfList;

        // Добавить элемент в список
        public void Add(string value)
        {
            if (head == null)
            {
                head = new ListElement(value, null);
                sizeOfList++;
                return;
            }

            if (head.value == value)
            {
                return;
            }

            var currentElement1 = head;
            var currentElement2 = head.next;
            while (currentElement2 != null)
            {
                if (currentElement2.value == value)
                {
                    return;
                }
                currentElement1 = currentElement2;
                currentElement2 = currentElement2.next;
            }
            sizeOfList++;
            currentElement1.next = new ListElement(value, null);
        }

        // Удалить элемент из списка
          public void Remove(string value)
          {
            if (head == null)
            {
                return;
            }
            if (head.value == value)
            {
                sizeOfList--;
                head = head.next;
                return;
            }
            var currentElement1 = head;
            var currentElement2 = currentElement1.next;
            while (currentElement2 != null)
            {
                if (currentElement2.value == value)
                {
                    sizeOfList--;
                    currentElement1.next = currentElement2.next;
                    return;
                }
            }
        }

        // Проверка списка на наличие в нем элемента 
        public bool IsContain(string value)
        {
            if (head == null)
            {
                return false;
            }
            ListElement currentElement = head;
            while (currentElement != null)
            {
                if (string.Compare(currentElement.value, value) == 0)
                {
                    return true;
                }
                currentElement = currentElement.next;
            }
            return false;
        }

        // Получить размер списка
        public int GetSize()
        => sizeOfList;
  

        // Проверка списка на пустоту
        public bool IsEmpty()
        => sizeOfList == 0 ? true : false;

        // Удалить и получить элемент списка
        public string Pop()
        {
            if (head != null)
            {
                sizeOfList--;
                var helpElement = head;
                head = head.next;
                return helpElement.value;
            }
            return null;
        }
    }
}