#pragma once

// ����������� ��� ������, �������������� ����� ������
// ���������, �������������� �� �������� LIFO
struct Stack
{
	char value;
	Stack* next;
};
// ���������� ������ �������� � ����
void push(char value, Stack** head);

// �������� �������� �������� �� �����
char pop(Stack** head);

// �������� �����
void deleteStack(Stack** head);

// �������� ����� �� �������
bool empty(Stack** head);