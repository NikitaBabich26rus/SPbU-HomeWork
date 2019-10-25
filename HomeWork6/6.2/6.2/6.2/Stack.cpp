#include "Stack.h"

using namespace std;

void push(Stack** head, char bracket)
{
	Stack* newBracket = new Stack;
	newBracket->bracket = bracket;
	newBracket->next = *head;
	*head = newBracket;
}

void deleteBracket(Stack** head)
{
	Stack *helpDelete = (*head)->next;
	delete* head;
	*head = helpDelete;
}
