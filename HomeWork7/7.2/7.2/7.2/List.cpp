#include <stdio.h>
#include "List.h"

struct ListElement
{
	int value;
	ListElement* next;
};

struct List
{
	ListElement* head = nullptr;
	ListElement* tail = nullptr;
};

List* createList()
{
	return new List;
}

bool empty(List* list)
{
	return list->head == nullptr;
}

void push(List* list, int value)
{
	if (empty(list))
	{
		list->tail = new ListElement{ value, nullptr };
		list->head = list->tail;
		list->tail->next = list->head;
	}
	else
	{
		list->tail->next = new ListElement{ value, list->head };
		list->tail = list->tail->next;
	}
}

void deleteElement(List* list, ListElement *parent)
{
	ListElement* helpElement = parent->next->next;
	if (list->head == parent->next)
	{
		list->head = helpElement;
	}
	delete parent->next;
	parent->next = helpElement;
}

void outputList(List* list)
{
	ListElement* helpElement = list->head;
	printf("%d ", helpElement->value);
	helpElement = helpElement->next;
	while (helpElement != list->head)
	{
		printf("%d ", helpElement->value);
		helpElement = helpElement->next;
	}
}
