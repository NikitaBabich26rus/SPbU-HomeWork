#include <stdio.h>
#include "List.h"
#include <string.h>


struct ListElement
{
	char string[sizeOfString];
	ListElement* next = nullptr;
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

void push(List* list, char string[])
{
	if (empty(list))
	{
		list->head = new ListElement;
		strcpy(list->head->string, string);
		return;
	}
	ListElement* currentElement = list->head;
	ListElement* helpElement = nullptr;
	while (currentElement != nullptr)
	{
		helpElement = currentElement;
		currentElement = currentElement->next;
	}
	helpElement->next = new ListElement;
	strcpy(helpElement->next->string, string);
}

bool contains(List* list, char string[])
{
	if (empty(list))
	{
		return false;
	}
	ListElement* currentElement = list->head;
	while (currentElement != nullptr)
	{
		if (strcmp(currentElement->string, string) == 0)
		{
			return true;
		}
		currentElement = currentElement->next;
	}
	return false;
}

void outputList(List* list)
{
	ListElement* currentElement = list->head;
	while (currentElement != nullptr)
	{
		printf("%s\n", currentElement->string);
		currentElement = currentElement->next;
	}
}

void deleteList(List* list)
{
	if (!empty(list))
	{
		while (list->head->next != nullptr)
		{
			ListElement* currentElement = list->head->next;
			delete list->head;
			list->head = currentElement;
		}
		delete list->head;
		delete list;
	}
}

void pushToNewListFromOldList(List* newList, List* oldList)
{
	if (!empty(oldList))
	{
		ListElement* currentElement = oldList->head;
		push(newList, currentElement->string);
		currentElement = currentElement->next;
		while (currentElement != nullptr)
		{
			if (!contains(newList, currentElement->string))
			{
				push(newList, currentElement->string);
			}
			currentElement = currentElement->next;
		}
	}
}

bool checkTest(List* list, char testArray[4][2])
{
	ListElement* currentElement = list->head;
	for (int i = 0; i < 4; i++)
	{
		if (strcmp(currentElement->string, testArray[i]) != 0)
		{
			return false;
		}
	}
	return true;
}