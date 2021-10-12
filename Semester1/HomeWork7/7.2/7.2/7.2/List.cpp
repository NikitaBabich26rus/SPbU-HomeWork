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
	if (list->tail == parent->next)
	{
		list->tail = parent;
	}
	delete parent->next;
	parent->next = helpElement;
}

void outputList(List* list)
{
	if (list->head == list->head->next)
	{
		printf("%d", list->head->value);
		return;
	}
	ListElement* helpElement = list->head;
	printf("%d ", helpElement->value);
	helpElement = helpElement->next;
	while (helpElement != list->head)
	{
		printf("%d ", helpElement->value);
		helpElement = helpElement->next;
	}
}

ListElement* takeTail(List* list)
{
	return list->tail;
}

ListElement* takeNextElement(ListElement* element)
{
	return element->next;
}

int takeValue(ListElement* element)
{
	return element->value;
}