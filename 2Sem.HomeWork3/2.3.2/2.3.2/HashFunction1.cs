using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
	/// <summary>
	/// Second hash function
	/// </summary>
    public class HashFunction1 : IHashFunction
    {
		public int HashFunction(string value , int hashSize)
		{
			int result = 0;
			for (int i = 0; i < value.Length; ++i)
			{
				result = (result + value[i]) % hashSize;
			}
			return result;

		}
    }
}
