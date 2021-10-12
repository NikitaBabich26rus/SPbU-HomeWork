#include "Stack.h"

void push(int value, Stack** head)
{
	Stack* newElement = new Stack;
	newElement->next = *head;
	newElement->value = value;
	*head = newElement;
}

void pop(Stack** head)
{
	Stack* newElement = (*head)->next;
	delete* head;
	*head = newElement;
}

void deleteStack(Stack** head)
{
	while (*head != nullptr)
	{
		pop(head);
	}
	delete* head;
}