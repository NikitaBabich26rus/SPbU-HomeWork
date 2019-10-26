
#include <stdio.h>
#include "Stack.h"
#include <string.h>


void operation(Stack **head, char operation)
{
	const int value1 = (*head)->next->value;
	const int value2 = (*head)->value;
	pop(head);
	pop(head);
	if (operation == '+')
	{
		push(value1 + value2, head);
	}
	if (operation == '*')
	{
		push(value1 * value2, head);
	}
	if (operation == '-')
	{
		push(value1 - value2, head);
	}
	if (operation == '/')
	{
		push(value1 / value2, head);
	}
}

void checkSymbol(Stack **head, char value)
{
	if (value >= '0' && value <= '9')
	{
		push(value - '0', head);
	}
	else
	{
		operation(head, value);
	}
}

void checkString(Stack** head, char string[], int size)
{
	for (int i = 0; i < size; i++)
	{
		if (string[i] != ' ')
		{
			checkSymbol(head, string[i]);
		}
	}
}

int checkAnswer(int myAnswer, int answer, int checkTest)
{
	if (myAnswer == answer)
	{
		printf("Program is correct\n");
		return checkTest;
	}
	else
	{
		printf("Program error\n");
		return -1;
	}
}

int tests()
{
	int checkTest = 0;
	Stack* headTest1 = nullptr;
	const int sizeTest1 = 21;
	char stringTest1[22] = "1 2 + 9 * 3 * 4 + 5 /";
	int answerTest1 = 17;
	printf("%s\n", stringTest1);
	checkString(&headTest1, stringTest1, sizeTest1);
	printf("My answer : ");
	printf("%d\n", headTest1->value);
	checkTest = checkAnswer(headTest1->value, answerTest1, checkTest);
	printf("\n");

	Stack* headTest2 = nullptr;
	const int sizeTest2 = 21;
	char stringTest2[22] = "5 7 - 9 * 2 * 6 + 6 /";
	int answerTest2 = -5;
	printf("%s\n", stringTest2);
	checkString(&headTest2, stringTest2, sizeTest2);
	printf("My answer : ");
	printf("%d\n", headTest2->value);
	checkTest = checkAnswer(headTest2->value, answerTest2, checkTest);
	printf("\n");
	return checkTest;
}

int main()
{
	printf("%d", tests());
	return 0;
}
