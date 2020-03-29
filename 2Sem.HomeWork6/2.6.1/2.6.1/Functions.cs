using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._1
{
    public class Functions
    {
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();
            foreach(var listElement in list)
            {
                newList.Add(function(listElement));
            }
            return newList;
        }
        
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var newList = new List<int>();
            foreach(var listElement in list)
            {
                if (function(listElement))
                {
                    newList.Add(listElement);
                }
            }
            return newList;
        }

        public static int Fold(List<int> list, int currentValue, Func<int, int, int> function)
        {
            foreach(var listElement in list)
            {
                currentValue = function(listElement, currentValue);
            }
            return currentValue;
        }
    }
}
