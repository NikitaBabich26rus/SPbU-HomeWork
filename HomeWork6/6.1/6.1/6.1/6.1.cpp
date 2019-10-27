
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Stack.h"

bool testCorrect(char string[])
{
	int amountValues = 0;
	for (int i = 0; string[i] != '\n'; i++)
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
	for (int i = 0; string[i] != '\n'; i++)
	{
		if (string[i] != ' ')
		{
			checkSymbol(head, string[i]);
		}
	}
}

int checkAnswer(int myAnswer, int answer, bool checkTest)
{
	if (myAnswer == answer)
	{
		return checkTest;
	}
	else
	{
		return false;
	}
}

int testing(char stringTest[])
{
	if (testCorrect(stringTest))
	{
		Stack* head = nullptr;
		checkString(&head, stringTest);
		int myAnswer = head->value;
		deleteStack(&head);
		return myAnswer;
	}
	return 0;
}

bool tests()
{
	bool checkTest1 = true;
	char stringTest1[23] = "1 2 + 9 * 3 * 4 + 5 /\n";
	int answerTest1 = 17;
	testCorrect(stringTest1);
	int myAnswerTest1 = testing(stringTest1);
	checkTest1 = checkAnswer(myAnswerTest1, answerTest1, checkTest1);

	bool checkTest2 = true;
	char stringTest2[23] = "5 7 - 9 * 2 * 6 + 6 /\n";
	int answerTest2 = -5;
	testCorrect(stringTest2);
	int myAnswerTest2 = testing(stringTest2);
	checkTest2 = checkAnswer(myAnswerTest2, answerTest2, checkTest2);
	return checkTest1 && checkTest2;
}

int main()
{
	if (!tests())
	{
		return -1;
	}
	else
	{
		char string[100]{};
		printf("Input string:\n");
		fgets(string, 100, stdin);
		if (testCorrect(string))
		{
			printf("%d", testing(string));
		}
		else
		{
			printf("Input is not correct");
		}
	}
	return 0;
}
