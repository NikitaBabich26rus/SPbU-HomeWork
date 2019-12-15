#include <stdio.h>
#include <string.h>
#include "List.h"
#include "HashTable.h"

struct ListElement
{
	char word[sizeOfWord]{};
	ListElement* next = nullptr;
	int amount = 0;
};

struct List
{
	ListElement* head = nullptr;
};

List* createList()
{
	return new List;
}

bool empty(List* list)
{
	return  list->head == nullptr;
}

void addToList(List* list, char word[], int amount)
{
	if (empty(list))
	{
		list->head = new ListElement;
		strcpy(list->head->word, word);
		list->head->amount = amount;
		return;
	}
	if (strcmp(list->head->word, word) == 0)
	{
		list->head->amount = amount;
		return;
	}
	ListElement* currentElement = list->head;
	while (currentElement->next != nullptr && strcmp(currentElement->next->word, word) != 0)
	{
		currentElement = currentElement->next;
	}
	if (currentElement->next == nullptr)
	{
		currentElement->next = new ListElement;
		strcpy(currentElement->next->word, word);
	}
	currentElement->next->amount = amount;
	return;
}

bool containsInList(List* list, char word[])
{
	if (empty(list))
	{
		return false;
	}
	ListElement* currentElement = list->head;
	while (currentElement != nullptr)
	{
		if (strcmp(currentElement->word, word) == 0)
		{
			return true;
		}
		currentElement = currentElement->next;
	}
	return false;
}

bool containsAndAddInList(List* list, char word[])
{
	if (empty(list))
	{
		return false;
	}
	ListElement* currentElement = list->head;
	while (currentElement != nullptr)
	{
		if (strcmp(currentElement->word, word) == 0)
		{
			currentElement->amount++;
			return true;
		}
		currentElement = currentElement->next;
	}
	return false;
}

void outputList(List* list)
{
	if (!empty(list))
	{
		ListElement* currentElement = list->head;
		while (currentElement != nullptr)
		{
			printf("Слово : ");
			printf("%s, ", currentElement->word);
			printf("Встретилось ");
			printf("%d ", currentElement->amount);
			printf("раз\n");
			currentElement = currentElement->next;
		}
	}
}

void deleteList(List* list)
{
	while (!empty(list))
	{
		ListElement* currentElement = list->head->next;
		delete list->head;
		list->head = currentElement;
	}
	delete list;
}

void pushToNewTableFromOldList(List* oldList, HashTable* newTable)
{
	if (!empty(oldList))
	{
		ListElement* currentElement = oldList->head;
		while (currentElement != nullptr)
		{
			List* helpList = getListFromTable(newTable, currentElement->word);
			addToList(helpList, currentElement->word, currentElement->amount);
			currentElement = currentElement->next;
		}
	}
}

int getSizeOfList(List* list)
{
	if (empty(list))
	{
		return 0;
	}
	int counter = 0;
	ListElement* currentElement = list->head;
	while (currentElement != nullptr)
	{
		counter++;
		currentElement = currentElement->next;
	}
	return counter;
}