
#include <stdio.h>
#include <string.h>
#include "Stack.h"

bool answer(Stack **head)
{
	if (*head == nullptr)
	{
		printf("Phrase is right\n");
		return true;
	}
	else
	{
		printf("Phrase is false\n");
		return false;
	}
}

void checkBracket(char bracket, Stack **head)
{
	bool check = true;
	if (*head != nullptr)
	{
		if (bracket == ')' && (*head)->value == '(')
		{
			pop(head);
			check = false;
		}
		if (bracket == ']' && (*head)->value == '[')
		{
			pop(head);
			check = false;
		}
		if (bracket == '}' && (*head)->value == '{')
		{
			pop(head);
			check = false;
		}
	}
	if (check)
	{
		push(bracket, head);
	}
}

void checkString(char string[], Stack **head)
{
	for (int i = 0; i < strlen(string); i++)
	{
		checkBracket(string[i], head);
	}
}

int checkAnswer(bool myAnswer, bool answer, bool checkTest)
{
	if (myAnswer == answer)
	{
		printf("Program is correct\n");
		return checkTest;
	}
	else
	{
		printf("Program error\n");
		return false;
	}
}

bool test()
{
	bool checkTest = true;
	Stack* headTest1 = nullptr;
	bool answerTest1 = false;
	printf("Size of string: ");
	char stringTest1[13] = "{[()()][]()}";
	printf("String:");
	printf("%s\n", stringTest1);
	checkString(stringTest1, &headTest1);
	bool myAnswerTest1 = answer(&headTest1);
	checkTest = checkAnswer(myAnswerTest1, answerTest1, checkTest);
	printf("\n");
	deleteStack(&headTest1);

	Stack* headTest2 = nullptr;
	bool answerTest2 = false;
	printf("Size of string: ");
	char stringTest2[21] = "({}({[()(()][]()}))";
	printf("String:");
	printf("%s\n", stringTest2);
	checkString(stringTest2, &headTest2);
	bool myAnswerTest2 = answer(&headTest2);
	checkTest = checkAnswer(myAnswerTest2, answerTest2, checkTest);
	printf("\n");
	deleteStack(&headTest1);
	return checkTest;
}

int main()
{
	return test() ? 0 : -1;
}

