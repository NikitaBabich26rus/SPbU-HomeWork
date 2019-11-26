
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
	int size = 0;
};

List* createList()
{
	return new List;
}

bool empty(List* list)
{
	return  list->head == nullptr;
}

void push(List* list, int value)
{
	if (empty(list))
	{
		list->head = new ListElement{ value, nullptr };
		list->size++;
		return;
	}
	ListElement* element1 = nullptr;
	ListElement* element2 = list->head;
	while (element2 != nullptr)
	{
		element1 = element2;
		element2 = element2->next;
	}
	element1->next = new ListElement{ value, element2 };
	list->size++;
}

void deleteElement(List* list, int value)
{
	if (!empty(list))
	{
		if (value == list->head->value)
		{
			ListElement* help = list->head->next;
			delete list->head;
			list->head = help;
			return;
		}
		ListElement* firstElement = list->head;
		ListElement* secondElement = nullptr;
		while (firstElement != nullptr)
		{
			if (value == firstElement->value)
			{
				ListElement* help = firstElement->next;
				delete firstElement;
				secondElement->next = help;
				break;
			}
			secondElement = firstElement;
			firstElement = firstElement->next;
		}
	}
}

bool checkSort(List* list)
{
	if (empty(list) || list->head->next == nullptr)
	{
		return true;
	}
	ListElement* firstElement = list->head->next;
	ListElement* secondElement = list->head;
	while (firstElement != nullptr)
	{
		if (secondElement->value > firstElement->value)
		{
			return false;
		}
		secondElement = firstElement;
		firstElement = firstElement->next;
	}
	return true;
}

bool contains(List* list, int value)
{
	if (empty(list))
	{
		return false;
	}
	ListElement* helpElement = list->head;
	while (helpElement != nullptr)
	{
		if (helpElement->value == value)
		{
			return true;
		}
		helpElement = helpElement->next;
	}
	return false;
}

void outputList(List* list)
{
	ListElement* helpElement = list->head;
	while (helpElement != nullptr)
	{
		printf("%d ", helpElement->value);
		helpElement = helpElement->next;
	}
}

void deleteList(List* list)
{
	while (!empty(list))
	{
		ListElement* helpElement = list->head->next;
		delete list->head;
		list->head = helpElement;
	}
	delete list;
}

int algotithm(List* list, int *lastPosition)
{
	ListElement* element = list->head;
	int count = 0;
	int size = 0;
	int maxPosition = 0;
	int position = 0;
	for (int i = 0; element->next != nullptr; i++)
	{
		if (element->value < element->next->value)
		{
			if (count == 0)
			{
				position = i;
			}
			count++;
		}
		else
		{
			if (count > size)
			{
				*lastPosition = i;
				size = count;
				maxPosition = position;
			}
			count = 0;
		}
		element = element->next;
		if (element->next == nullptr && count != 0)
		{
			if (count > size)
			{
				*lastPosition = i + 1;
				size = count;
				maxPosition = position;
			}
		}
	}
	return maxPosition;
}

void pustToNewListFromOldList(List* list, List *newList, int position, int *lastPosition)
{
	ListElement* helpElement = list->head;
	for (int i = 0; i <= *lastPosition; i++)
	{
		if (i >= position)
		{
			push(newList, helpElement->value);
		}
		helpElement = helpElement->next;
	}
}
