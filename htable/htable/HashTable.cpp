#include"Hashtable.h"
#include <string.h>
#include "List.h"
#include <stdio.h>


struct HashTable
{
	int amountOfDifferentElements = 0;
	int hashSize = 3;
	List** arrayOfTable = new List*[hashSize];
};

HashTable* createHashTable()
{
	HashTable* table = new HashTable;
	for (int i = 0; i < table->hashSize; i++)
	{
		table->arrayOfTable[i] = createList();
	}
	return table;
}

int hashFunction(HashTable* table, char word[])
{
	int result = 0;
	for (int i = 0; word[i] != '\0'; ++i)
		result = (result + word[i]) % table->hashSize;
	return result;
}

bool containsInTableAndAddElement(HashTable* table, char word[])
{
	return containsAndAddInList(table->arrayOfTable[hashFunction(table, word)], word);
}

HashTable* addToTable(HashTable* table, char word[], int amount)
{
	if (!containsInTableAndAddElement(table, word))
	{
		table->amountOfDifferentElements++;
		addToList(table->arrayOfTable[hashFunction(table, word)], word, amount);
		if (table->amountOfDifferentElements / float(table->hashSize) > 1.2)
		{
			table = resizeOfTable(table);
		}
	}
	return table;
}

bool containsInTable(HashTable* table, char word[])
{
	return containsInList(table->arrayOfTable[hashFunction(table, word)], word);
}

void deleteTable(HashTable* table)
{
	for (int i = 0; i < table->hashSize; i++)
	{
		deleteList(table->arrayOfTable[i]);
	}
	delete table;
}

void outputTable(HashTable* table)
{
	for (int i = 0; i < table->hashSize; i++)
	{
		outputList(table->arrayOfTable[i]);
	}
}

void outputResultOfProgram(HashTable* table)
{
	float sumOfListLengths = 0;
	float amountOfLists = 0;
	int maxListLenght = 0;
	for (int i = 0; i < table->hashSize; i++)
	{
		int listLength = getSizeOfList(table->arrayOfTable[i]);
		if (listLength > maxListLenght)
		{
			maxListLenght = listLength;
		}
		sumOfListLengths += listLength;
		if (listLength > 0)
		{
			amountOfLists++;
		}
	}
	printf("Коэффицент заполнения хеш-таблицы : ");
	printf("%f\n", table->amountOfDifferentElements / float(table->hashSize));
	printf("Максимальная длина сегмента хеш-таблицы : ");
	printf("%d\n", maxListLenght);
	printf("Средняя длина сегмента хеш-таблицы : ");
	printf("%f\n", float(sumOfListLengths / amountOfLists));
}

List* getListFromTable(HashTable* table, char word[])
{
	return  table->arrayOfTable[hashFunction(table, word)];
}

HashTable* resizeOfTable(HashTable* oldTable)
{
	HashTable* newTable = new HashTable;
	newTable->hashSize = oldTable->hashSize * 2;
	newTable->amountOfDifferentElements = oldTable->amountOfDifferentElements;
	newTable->arrayOfTable = new List* [newTable->hashSize];
	for (int i = 0; i < newTable->hashSize; i++)
	{
		newTable->arrayOfTable[i] = createList();
	}
	for (int i = 0; i < oldTable->hashSize; i++)
	{
		pushToNewTableFromOldList(oldTable->arrayOfTable[i], newTable);
	}
	deleteTable(oldTable);
	return newTable;
}