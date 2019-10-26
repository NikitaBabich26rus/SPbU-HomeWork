#include "Stack.h"

void push(Stack** head, char bracket)
{
	Stack* newBracket = new Stack;
	newBracket->bracket = bracket;
	newBracket->next = *head;
	*head = newBracket;
}

void pop(Stack** head)
{
	Stack *helpDelete = (*head)->next;
	delete* head;
	*head = helpDelete;
}
