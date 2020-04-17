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
		/// Add element in hash table
		/// </summary>
		/// <param name="value">Element value</param>
		public void Add(string value)
		{
			int hashValue = hash.HashFunction(value, hashTableArray.Length);
			if (hashValue < 0 || hashValue >= hashTableArray.Length)

			{
				throw new InvalidHashValueException();
			}

			hashTableArray[hashValue].Add(value);
			amountOfElements++;

			if ((float)amountOfElements / (float)hashTableArray.Length > 1.2)
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
			var newHashTableArray = new List[hashTableArray.Length];
			
			for (int i = 0; i < hashTableArray.Length; i++)
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
						newHashTableArray[hash.HashFunction(currentValue, hashTableArray.Length)].Add(currentValue);
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
			int size = hashTableArray.Length * 2;
			var newHashTableArray = new List[size];

			for (int i = 0; i < newHashTableArray.Length; i++)
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
						int hashValue = hash.HashFunction(currentValue, newHashTableArray.Length);
						if (hashValue < 0 || hashValue >= newHashTableArray.Length)
						{
							throw new InvalidHashValueException();
						}
						newHashTableArray[hashValue].Add(currentValue);
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
			if (hashTableArray.Length != 0)
			{
				hashTableArray[hash.HashFunction(value, hashTableArray.Length)].Remove(value);
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
			return hashTableArray[hash.HashFunction(value, hashTableArray.Length)].IsContain(value);
		}
	}
}
