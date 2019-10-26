#pragma once

struct Stack
{
	int value;
	Stack* next;
};

void push(int value, Stack** head);

void pop(Stack** head);