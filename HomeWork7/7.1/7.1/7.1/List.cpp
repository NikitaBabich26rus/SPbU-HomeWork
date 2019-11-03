#include <stdio.h>
#include "List.h"


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
	}
	else
	{
		ListElement* element1 = nullptr;
		ListElement* element2 = list->head;
		while (element2 != nullptr && value > element2->value)
		{
			element1 = element2;
			element2 = element2->next;
		}
		if (element1 == nullptr)
		{
			list->head = new ListElement{ value, element2 };
		}
		else
		{
			element1->next = new ListElement{ value, element2 };
		}
	}
}

void deleteElement(List *list, int value)
{
	if (value == list->head->value)
	{
		ListElement* help = list->head->next;
		delete list->head;
		list->head = help;
	}
	else
	{
		ListElement* firstElement = list->head;
		ListElement* secondElement = nullptr;
		while (firstElement != nullptr)
		{
			if (value == firstElement->value)
			{
				ListElement* help = firstElement->next;
				delete firstElement->next;
				secondElement->next = help;
				break;
			}
			secondElement = firstElement;
			firstElement = firstElement->next;
		}
	}
}

bool checkSort(List *list)
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

bool checkElement(List* list, int value)
{
	if (empty(list))
	{
		return false;
	}
	else
	{
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