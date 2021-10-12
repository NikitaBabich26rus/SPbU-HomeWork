#pragma once

// ����������� ��� ������, �������������� ����� ������
// ���������, �������������� �� �������� LIFO

struct Stack
{
	int value;
	Stack* next;
};

// ���������� ������ �������� � ����
void push(int value, Stack** head);

// �������� �������� �������� �� �����
void pop(Stack** head);

// �������� �����
void deleteStack(Stack** head);