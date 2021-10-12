﻿using System;
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
			int hashValue = ConvertHashCode(hash.HashFunction(value), hashTableArray.Length);
			hashTableArray[hashValue].Add(value);
			amountOfElements++;
			if ((float)amountOfElements / (float)hashTableArray.Length > 1.2)
			{
				HashTableResize();
			}
		}

		/// <summary>
		/// Change hash function in hash table
		/// </summary>
		/// <param name="newHash">New hash function</param>
		public void ChangeHashFunction(IHashFunction newHash)
		{
			this.hash = newHash;
			var newHashTableArray = new List[hashTableArray.Length];
			hashTableArray = TransferDataFromTheOldTableToTheNew(newHashTableArray);
		}

		/// <summary>
		/// Resize of hash table
		/// </summary>
		/// <returns>New array of hash table</returns>
		private void HashTableResize()
		{
			int size = hashTableArray.Length * 2;
			var newHashTableArray = new List[size];
			hashTableArray = TransferDataFromTheOldTableToTheNew(newHashTableArray);
		}

		/// <summary>
		/// Transfer data from the old hashTableArrar to the new hash table array.
		/// </summary>
		/// <param name="newHashTableArray">List array - new hash table array.</param>
		/// <returns></returns>
		private List[] TransferDataFromTheOldTableToTheNew(List[] newHashTableArray)
		{
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
						var hashValue = ConvertHashCode(hash.HashFunction(currentValue), newHashTableArray.Length);
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
			if (amountOfElements == 0)
			{
				return;
			}
			var hashValue = ConvertHashCode(hash.HashFunction(value), hashTableArray.Length);
			if (!hashTableArray[hashValue].Remove(value))
			{
				amountOfElements--;
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
			var hashValue = ConvertHashCode(hash.HashFunction(value), hashTableArray.Length);
			return hashTableArray[hashValue].IsContain(value);
		}

		/// <summary>
		/// Convert the hash code.
		/// </summary>
		/// <param name="hashValue">Hash value.</param>
		/// <returns>Array index value not beyond its scope.</returns>
		private int ConvertHashCode(int hashValue, int size) => System.Math.Abs(hashValue % size);
	}
}
