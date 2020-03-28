using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2._2
{
	public class HashTable
	{
		private List[] hashTableArray = new List[5];
		private int amountOfElements = 0;

		public HashTable()
		{
			for (int i = 0; i < hashTableArray.Length; i++)
			{
				hashTableArray[i] = new List();
			}
		}

		// Хеш функция
		private int HashFunction(string value, int size)
		{
			int result = 0;
			for (int i = 0; i < value.Length; ++i)
			{
				result = (result + value[i]) % size;
			}
			return result;
		}

		// Добавить элемент в Хеш таблицу
		public void Add(string value)
		{
			hashTableArray[HashFunction(value, hashTableArray.Length)].Add(value);
			amountOfElements++;

			if ((float)amountOfElements / (float)hashTableArray.Length > 1.2)
			{
				hashTableArray = HashTableResize();
			}
		}
		
		// Изменить размер хеш таблицы
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
						newHashTableArray[HashFunction(currentValue, newHashTableArray.Length)].Add(currentValue);
					}
				}
			}
			return newHashTableArray;
		}

		// Удалить элемент из хеш таблицы
		public void Remove(string value)
		{
			hashTableArray[HashFunction(value, hashTableArray.Length)].Remove(value);
		}

		// Проверка таблицы на наличие в ней элемента
		public bool IsContain(string value)
			=> hashTableArray[HashFunction(value, hashTableArray.Length)].IsContain(value);
	}
}

