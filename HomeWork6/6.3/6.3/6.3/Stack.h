#pragma once

// Абстрактный тип данных, представляющий собой список
// элементов, организованных по принципу LIFO
struct Stack
{
	char value;
	Stack* next;
};
// Добавление нового элемента в стек
void push(char value, Stack** head);

// Удаление верхнего элемента из стека
char pop(Stack** head);

// Удаление стека
void deleteStack(Stack** head);