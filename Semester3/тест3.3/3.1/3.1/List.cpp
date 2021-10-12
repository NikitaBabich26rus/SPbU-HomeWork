#include <stdio.h>
#include "List.h"


struct ListElement
{
	int value = 0;
	ListElement* next;
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

void push(List* list, int value)
{
	if (empty(list))
	{
		list->head = new ListElement{ value, nullptr, 1 };
		return;
	}
	ListElement* element1 = list->head;
	ListElement* element2 = list->head->next;
	if (value < element1->value)
	{
		list->head = new ListElement{ value, list->head, 1 };
		return;
	}
	if (value > element1->value && element2 == nullptr)
	{
		element1->next = new ListElement{value, nullptr, 1};
		return;
	}
	if (value == element1->value)
	{
		element1->amount++;
		return;
	}
	while (true)
	{
		if (element2 == nullptr)
		{
			ListElement* helpElement = new ListElement{ value, nullptr, 1 };
			element1->next = helpElement;
			return;
		}
		if (element2->value > value && element1->value < value)
		{
			ListElement* helpElement = new ListElement{ value, element2, 1 };
			element1->next = helpElement;
			return;
		}
		if (element2->value == value)
		{
			element2->amount++;
			return;
		}
		element1 = element2;
		element2 = element2->next;
	}
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
		printf("Элемент : ");
		printf("%d ", helpElement->value);
		printf("Количество элементов : ");
		printf("%d\n", helpElement->amount);
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