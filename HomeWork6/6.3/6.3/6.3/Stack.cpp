#include "Stack.h"

void push(char value, Stack** head)
{
	Stack* newElement = new Stack;
	newElement->next = *head;
	newElement->value = value;
	*head = newElement;
}

char pop(Stack** head)
{
	char element = (*head)->value;
	Stack* newElement = (*head)->next;
	delete* head;
	*head = newElement;
	return element;
}

void deleteStack(Stack** head)
{
	while (*head != nullptr)
	{
		pop(head);
	}
	delete* head;
}

bool empty(Stack** head)
{
	return *head == nullptr;
}