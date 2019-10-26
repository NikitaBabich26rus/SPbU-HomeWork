
#include "Stack.h"

using namespace std;

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
	delete *head;
	*head = newElement;
}