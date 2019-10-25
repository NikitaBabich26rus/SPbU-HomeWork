
#include <stdio.h>
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
		if (bracket == ')' && (*head)->bracket == '(')
		{
			deleteBracket(head);
			check = false;
		}
		if (bracket == ']' && (*head)->bracket == '[')
		{
			deleteBracket(head);
			check = false;
		}
		if (bracket == '}' && (*head)->bracket == '{')
		{
			deleteBracket(head);
			check = false;
		}
	}
	if (check)
	{
		push(head, bracket);
	}
}

void checkString(int size, char string[], Stack **head)
{
	for (int i = 0; i < size; i++)
	{
		checkBracket(string[i], head);
	}
}

void checkAnswer(bool myAnswer, bool answer)
{
	if (myAnswer == answer)
	{
		printf("Program is correct\n");
	}
	else
	{
		printf("Program error\n");
	}
}

void test()
{
	Stack* headTest1 = nullptr;
	const int sizeTest1 = 12;
	bool answerTest1 = true;
	printf("Size of string: ");
	printf("%d\n", sizeTest1);
	char stringTest1[13] = "{[()()][]()}";
	printf("String:");
	printf("%s\n", stringTest1);
	checkString(sizeTest1, stringTest1, &headTest1);
	bool myAnswerTest1 = answer(&headTest1);
	checkAnswer(myAnswerTest1, answerTest1);
	printf("\n");

	Stack* headTest2 = nullptr;
	const int sizeTest2 = 22;
	bool answerTest2 = false;
	printf("Size of string: ");
	printf("%d\n", sizeTest2);
	char stringTest2[21] = "({}({[()(()][]()}))";
	printf("String:");
	printf("%s\n", stringTest2);
	checkString(sizeTest2, stringTest2, &headTest2);
	bool myAnswerTest2 = answer(&headTest2);
	checkAnswer(myAnswerTest2, answerTest2);
	printf("\n");
}

int main()
{
	test();
	return 0;
}

