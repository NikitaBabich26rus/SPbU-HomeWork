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
	int sizeOfList = 0;
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
	list->sizeOfList ++;
	if (empty(list))
	{
		list->head = new ListElement;
		strcpy(list->head->word, word);
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

ListElement* getListHead(List* list)
{
	if (!empty(list))
	{
		return list->head;
	}
}

ListElement* getNextListElement(ListElement* element)
{
	if (element != nullptr)
	{
		return element->next;
	}
}

char* getWordOfListElement(ListElement* element)
{
	if (element != nullptr)
	{
		return element->word;
	}
}

int getAmountOfListElement(ListElement* element)
{
	if (element != nullptr)
	{
		return element->amount;
	}
}

int getSizeOfList(List* list)
{
	if (empty(list))
	{
		return 0;
	}
	return list->sizeOfList;
}