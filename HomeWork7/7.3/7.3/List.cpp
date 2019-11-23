
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
	ListElement* previos = nullptr;
};

List* createList()
{
	return new List;
}

bool empty(List* list)
{
	return list->head == nullptr;
}

int takeListSize(List* list)
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
		return;
	}
	list->tail->next = new ListElement;
	list->tail->next->previos = list->tail;
	list->tail = list->tail->next;
	strcpy(list->tail->mainString, mainString);
	strcpy(list->tail->sideString, sideString);
	list->size = list->size + 1;
}

void output(List* list)
{
	ListElement* helpElement = list->head;
	for (;helpElement != nullptr;)
	{
		printf("%s ", helpElement->mainString);
		printf("%s\n", helpElement->sideString);
		helpElement = helpElement->next;		
	}
}

List* createNewRightList(List* list, int size)
{
	ListElement* helpElement = list->tail;
	List* rightList = createList();
	for (int i = size; i >= size / 2 + bool(size % 2); i--)
	{
		char mainString[sizeOfString]{};
		char sideString[sizeOfString]{};
		strcpy(mainString, helpElement->mainString);
		strcpy(sideString, helpElement->sideString);
		push(rightList, mainString, sideString);
		helpElement = helpElement->previos;
		delete[] mainString;
		delete[] sideString;
	}
	return rightList;
}

List* createNewLeftList(List* list, int size)
{
	ListElement* helpElement = list->head;
	List* leftList = createList();
	for (int i = 1; i <= size / 2; i++)
	{
		char mainString[sizeOfString]{};
		char sideString[sizeOfString]{};
		strcpy(mainString, helpElement->mainString);
		strcpy(sideString, helpElement->sideString);
		push(leftList, mainString, sideString);
		helpElement = helpElement->next;
		delete[] mainString;
		delete[] sideString;
	}
	return leftList;
}

void pushToNewList(List* list, List* leftList, List* rightList)
{
	char mainString[sizeOfString]{};
	char sideString[sizeOfString]{};
	if (strcmp(leftList->head->mainString, rightList->head->mainString) >= 0)
	{
		strcpy(mainString, leftList->head->mainString);
		strcpy(sideString, leftList->head->sideString);
		push(list, mainString, sideString);
		leftList->head = leftList->head->next;
		delete leftList->head->previos;
		delete[] mainString;
		delete[] sideString;
		return;
	}
	strcpy(mainString, rightList->head->mainString);
	strcpy(sideString, rightList->head->sideString);
	push(list, mainString, sideString);
	rightList->head = rightList->head->next;
	delete rightList->head->previos;
	delete[] mainString;
	delete[] sideString;
}

void transferLastValues(List* oldList, List* newList)
{
	ListElement* helpElement = oldList->head;
	while (helpElement != nullptr)
	{
		char mainString[sizeOfString]{};
		char sideString[sizeOfString]{};
		strcpy(mainString, helpElement->mainString);
		strcpy(sideString, helpElement->sideString);
		push(newList, mainString, sideString);
		helpElement = helpElement->next;
		delete[] mainString;
		delete[] sideString;
	}
}