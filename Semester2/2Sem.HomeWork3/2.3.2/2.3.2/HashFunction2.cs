using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
    /// <summary>
    /// Second hash function
    /// </summary>
    public class HashFunction2 : IHashFunction
    {
        /// <summary>
        /// Get element`s hash code
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <returns>Element`s hash code</returns>
        public int HashFunction(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                result += value[i];
            }
            return result;
        }
    }
}
