
#include <stdio.h>
#include "Stack.h"
#include <string.h>

bool testCorrect(char string[])
{
	int amountValues = 0;
	for (int i = 0; i < strlen(string); i++)
	{
		if (string[i] != ' ')
		{
			if (string[i] >= '0' && string[i] <= '9')
			{
				amountValues++;
			}
			if (string[i] == '+' || string[i] == '-' || string[i] == '*' || string[i] == '/')
			{
				if (amountValues < 2)
				{
					return false;
				}
				amountValues--;
			}
		}
	}
	return true;
}

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

void checkString(Stack** head, char string[])
{
	for (int i = 0; i < strlen(string); i++)
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

int testing(Stack** headTest, char stringTest[], int checkTest, int answerTest)
{
	if (testCorrect(stringTest))
	{
		checkString(headTest, stringTest);
		printf("My answer : ");
		printf("%d\n", (*headTest)->value);
		checkTest = checkAnswer((*headTest)->value, answerTest, checkTest);
		deleteStack(headTest);
		return checkTest;
	}
	else
	{
		printf("Test is not correct\n");
		return -1;
	}
}

void tests()
{
	int checkTest = 0;
	Stack* headTest1 = nullptr;
	char stringTest1[22] = "1 2 + 9 * * 4 + 5 /";
	int answerTest1 = 17;
	printf("%s\n", stringTest1);
	checkTest = testing(&headTest1, stringTest1, checkTest, answerTest1);
	printf("\n");

	Stack* headTest2 = nullptr;
	char stringTest2[22] = "5 7 - 9 * 2 * 6 + 6 /";
	int answerTest2 = -5;
	printf("%s\n", stringTest2);
	testing(&headTest2, stringTest2, checkTest, answerTest2);
	printf("\n");
	printf("%d\n", checkTest);
}

int main()
{
	tests();
	return 0;
}
