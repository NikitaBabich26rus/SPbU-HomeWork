using System;
using System.Collections.Generic;
using System.Text;

namespace _2._3._2
{
	/// <summary>
	/// Hash table on the array of lists
	/// </summary>
	public class HashTable
	{
		private List[] hashTableArray = new List[2];
		private int amountOfElements = 0;
		private int hashTableSize = 2;
		private IHashFunction hash;

		/// <summary>
		/// Constructor of hash table
		/// </summary>
		/// <param name="length">Length of hash table</param>
		/// <param name="hash">Chosen hash function</param>
		public HashTable(IHashFunction hash)
		{
			for (int i = 0; i < hashTableArray.Length; i++)
			{
				hashTableArray[i] = new List();
			}

			this.hash = hash;
		}

		/// <summary>
		/// Get size of the hash table
		/// </summary>
		/// <returns>Size</returns>
		public int GetHashTableSize() => hashTableSize;

		/// <summary>
		/// Add element in hash table
		/// </summary>
		/// <param name="Element value"></param>
		public void Add(string value)
		{
			hashTableArray[hash.HashFunction(value, hashTableSize)].Add(value);
			amountOfElements++;

			if ((float)amountOfElements / (float)hashTableSize > 1.2)
			{
				hashTableArray = HashTableResize();
			}
		}

		/// <summary>
		/// Change hash function in hash table
		/// </summary>
		/// <param name="newHash">New hash function</param>
		public void ChangeHashFunction(IHashFunction newHash)
		{
			hash = newHash;
			var newHashTableArray = new List[hashTableSize];
			
			for (int i = 0; i < hashTableSize; i++)
			{
				newHashTableArray[i] = new List();
			}

			for (int i = 0; i < hashTableArray.Length; i++)
			{
				while (!hashTableArray[i].IsEmpty())
				{
					var currentValue = hashTableArray[i].Pop();
					if (currentValue != null)
					{
						newHashTableArray[hash.HashFunction(currentValue, hashTableSize)].Add(currentValue);
					}
				}
			}
			hashTableArray = newHashTableArray;
		}

		/// <summary>
		/// Resize of hash table
		/// </summary>
		/// <returns>New array of hash table</returns>
		private List[] HashTableResize()
		{
			hashTableSize = hashTableSize * 2;
			var newHashTableArray = new List[hashTableSize];

			for (int i = 0; i < hashTableSize; i++)
			{
				newHashTableArray[i] = new List();
			}

			for (int i = 0; i < hashTableArray.Length; i++)
			{
				while (!hashTableArray[i].IsEmpty())
				{
					var currentValue = hashTableArray[i].Pop();
					if (currentValue != null)
					{
						newHashTableArray[hash.HashFunction(currentValue, hashTableSize)].Add(currentValue);
					}
				}
			}
			return newHashTableArray;
		}

		/// <summary>
		/// Delete element of hash table
		/// </summary>
		/// <param name="value">Value Of element</param>
		public void Remove(string value)
		{
			if (hashTableSize != 0)
			{
				hashTableArray[hash.HashFunction(value, hashTableSize)].Remove(value);
			}
		}

		/// <summary>
		/// Check element for hash table belong
		/// </summary>
		/// <param name="value">Value of element</param>
		/// <returns>Contained or not</returns>
		public bool IsContain(string value)
		{
			if (amountOfElements == 0)
			{
				return false;
			}
			return hashTableArray[hash.HashFunction(value, hashTableSize)].IsContain(value);
		}
	}
}
