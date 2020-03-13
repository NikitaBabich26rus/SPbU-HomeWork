#include"Hashtable.h"
#include <string.h>
#include "List.h"
#include <stdio.h>


struct HashTable
{
	int amountOfDifferentElements = 0;
	int hashSize = 5;
	List** arrayOfTable = new List*[hashSize];
};

HashTable* createHashTable(int hashSize)
{
	HashTable* newTable = new HashTable;
	newTable->hashSize = hashSize;
	newTable->arrayOfTable = new List * [newTable->hashSize];
	for (int i = 0; i < newTable->hashSize; i++)
	{
		newTable->arrayOfTable[i] = createList();
	}
	return newTable;
}

int hashFunction(HashTable* table, char word[])
{
	int result = 0;
	for (int i = 0; word[i] != '\0'; ++i)
		result = (result + word[i]) % (table->hashSize);
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
			outputResultOfProgram(table);
			table = resizeOfTable(table);
			outputResultOfProgram(table);
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
	int maxListLength = 0;
	for (int i = 0; i < table->hashSize; i++)
	{
		int listLength = getSizeOfList(table->arrayOfTable[i]);
		if (listLength > maxListLength)
		{
			maxListLength = listLength;
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
	printf("%d\n", maxListLength);     
	printf("Средняя длина сегмента хеш-таблицы : ");
	printf("%f\n", float(sumOfListLengths / amountOfLists));
}

List* getListFromTable(HashTable* table, char word[])
{
	return  table->arrayOfTable[hashFunction(table, word)];
}

void pushToNewTableFromOldList(List* oldList, HashTable* newTable)
{
	if (!empty(oldList))
	{
		ListElement* currentElement = getListHead(oldList);
		while (currentElement != nullptr)
		{
			List* helpList = getListFromTable(newTable, getWordOfListElement(currentElement));
			addToList(helpList, getWordOfListElement(currentElement), getAmountOfListElement(currentElement));
			currentElement = getNextListElement(currentElement);
		}
	}
}

HashTable* resizeOfTable(HashTable* oldTable)
{
	HashTable* newTable = createHashTable(oldTable->hashSize * 2);
	newTable->amountOfDifferentElements = oldTable->amountOfDifferentElements;
	for (int i = 0; i < oldTable->hashSize; i++)
	{
		pushToNewTableFromOldList(oldTable->arrayOfTable[i], newTable);
	}
	deleteTable(oldTable);
	return newTable;
}

