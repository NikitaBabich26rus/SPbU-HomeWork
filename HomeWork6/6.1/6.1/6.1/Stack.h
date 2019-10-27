#pragma once

// Абстрактный тип данных, представляющий собой список
// элементов, организованных по принципу LIFO
struct Stack
{
	int value;
	Stack* next;
};
// Добавление нового элемента в стек
void push(int value, Stack** head);

// Удаление верхнего элемента из стека
void pop(Stack** head);

// Удаление стека
void deleteStack(Stack** head);