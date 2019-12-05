#include "List.h"
#include <string.h>
#include <stdio.h>

struct List
{
	ListElement* head = nullptr;
	ListElement* tail = nullptr;
	int size = 0;
};

struct ListElement
{
	char mainString[sizeOfString]{};
	char sideString[sizeOfString]{};
	ListElement* next = nullptr;
	ListElement* previous = nullptr;
};

List* createList()
{
	return new List;
}

bool empty(List* list)
{
	return list->head == nullptr;
}

int getListSize(List* list)
{
	return list->size;
}

void push(List* list, char mainString[], char sideString[])
{
	if (list->head == nullptr)
	{
		list->head = new ListElement;
		strcpy(list->head->mainString, mainString);
		strcpy(list->head->sideString, sideString);
		list->tail = list->head;
		list->size = 1;
		return;
	}
	list->tail->next = new ListElement;
	list->tail->next->previous = list->tail;
	list->tail = list->tail->next;
	strcpy(list->tail->mainString, mainString);
	strcpy(list->tail->sideString, sideString);
	list->size++;
}

void output(List* list)
{
	ListElement* helpElement = list->head;
	while (helpElement != nullptr)
	{
		printf("%s ", helpElement->mainString);
		printf("%s\n", helpElement->sideString);
		helpElement = helpElement->next;
	}
}

void createNewRightList(List* list, List* rightList, int size)
{
	ListElement* helpElement = list->tail;
	for (int i = size - 1; i >= size / 2; i--)
	{
		push(rightList, helpElement->mainString, helpElement->sideString);
		helpElement = helpElement->previous;
	}
}

void createNewLeftList(List* list, List* leftList, int size)
{
	ListElement* helpElement = list->head;
	for (int i = 0; i < size / 2; i++)
	{
		push(leftList, helpElement->mainString, helpElement->sideString);
		helpElement = helpElement->next;
	}
}

void deleteHead(List* list)
{
	if (!empty(list))
	{
		if (list->head->next == nullptr)
		{
			delete list->head;
			list->head = nullptr;
			list->tail = nullptr;
			list->size = 0;
			return;
		}
		ListElement* helpElement = list->head->next;
		delete list->head;
		list->head = helpElement;
		list->size = list->size - 1;
		list->head->previous = nullptr;
	}
}

void pushToNewList(List* list, List* leftList, List* rightList)
{
	if (strcmp(leftList->head->mainString, rightList->head->mainString) >= 0)
	{
		push(list, rightList->head->mainString, rightList->head->sideString);
		deleteHead(rightList);
		return;
	}
	push(list, leftList->head->mainString, leftList->head->sideString);
	deleteHead(leftList);
}

void transferLastValues(List* oldList, List* newList)
{
	ListElement* helpElement = oldList->head;
	while (helpElement != nullptr)
	{
		push(newList, helpElement->mainString, helpElement->sideString);
		helpElement = helpElement->next;
	}
}

bool checkSort(List* list)
{
	ListElement* firstElement = list->head;
	ListElement* secondElement = nullptr;
	while (firstElement->next != nullptr)
	{
		secondElement = firstElement;
		firstElement = firstElement->next;
		if (strcmp(secondElement->mainString, firstElement->mainString) > 0)
		{
			return false;
		}
	}
	return true;
}

void deleteList(List* list)
{
	if (!empty(list))
	{
		while (list->head->next != nullptr)
		{
			ListElement* helpElement = list->head->next;
			delete list->head;
			list->head = helpElement;
			helpElement->previous = nullptr;
		}
		delete list->head;
		delete list;
	}
}