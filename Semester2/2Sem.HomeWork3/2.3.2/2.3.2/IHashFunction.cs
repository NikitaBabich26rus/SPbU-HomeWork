using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
    /// <summary>
    /// Hash function interface.
    /// </summary>
    public interface IHashFunction
    {
        /// <summary>
        /// Get element`s hash code
        /// </summary>
        /// <param name="value">Element`s value.</param>
        /// <returns>Element`s hash code.</returns>
        public int HashFunction(string value);
    }
}
