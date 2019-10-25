#pragma once

// abstract data type, which is a list of elements organized according to the LIFO principle


struct Stack
{
	char bracket;
	Stack* next;
};


void push(Stack** head, char bracket);

void deleteBracket(Stack** head);