using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    /// <summary>
    /// Cell class
    /// </summary>
    public class Cell
    {
        /// <summary>
        ///  is pushed cell?
        /// </summary>
        public bool IsPushed { get; set; } = false;

        /// <summary>
        /// Value of cell
        /// </summary>
        public string Value { get; set; }

    }
}
