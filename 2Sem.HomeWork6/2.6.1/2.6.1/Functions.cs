using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._1
{
    /// <summary>
    /// Function class
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Map function converts list elements
        /// </summary>
        /// <param name="list">List with elements</param>
        /// <param name="function">Function</param>
        /// <returns>newList</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();
            foreach (var listElement in list)
            {
                newList.Add(function(listElement));
            }
            return newList;
        }

        /// <summary>
        /// Filter accepts a list and a function that returns a Boolean value on a list element.
        /// </summary>
        /// <param name="list">List with elements</param>
        /// <param name="function">Function</param>
        /// <returns></returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var newList = new List<int>();
            foreach (var listElement in list)
            {
                if (function(listElement))
                {
                    newList.Add(listElement);
                }
            }
            return newList;
        }

        /// <summary>
        /// Fold function takes a list, an initial value, and a function that takes the current accumulated value
        /// and the current list element, and returns the next accumulated value.
        /// </summary>
        /// <param name="list">List with elements</param>
        /// <param name="currentValue">Current accumulated value</param>
        /// <param name="function">Function</param>
        /// <returns></returns>
        public static int Fold(List<int> list, int currentValue, Func<int, int, int> function)
        {
            foreach (var listElement in list)
            {
                currentValue = function(listElement, currentValue);
            }
            return currentValue;
        }
    }
}
