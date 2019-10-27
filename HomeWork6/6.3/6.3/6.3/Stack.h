#pragma once

struct Stack
{
	char value;
	Stack* next;
};

void push(char value, Stack** head);

char pop(Stack** head);