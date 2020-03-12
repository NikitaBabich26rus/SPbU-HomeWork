using System;
using System.Collections.Generic;
using System.Text;

namespace _2._4._2
{
    /// <summary>
    /// List class without duplicate elements. 
    /// </summary>
    public class UniqueList : List
    {
        ListElement head { get; set; }

        /// <summary>
        /// Add new element in UniqueList
        /// </summary>
        /// <param name="value">Value of element</param>
        public override void Add(int value)
        {
            if (IsContain(value))
            {
                throw new AddContainingValueException($"Error : {value} is contained in the list"); 
            }
            base.Add(value);
        }
    }
}
