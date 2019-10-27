
#include <stdio.h>
#include <string.h>
#include "Stack.h"

bool answer(Stack **head)
{
	if (*head == nullptr)
	{
		return true;
	}
	else
	{
		deleteStack(head);
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
		return checkTest;
	}
	else
	{
		return false;
	}
}

bool checkBalance(char stringTest[])
{
	Stack* head = nullptr;
	checkString(stringTest, &head);
	return answer(&head);
}

bool test()
{
	bool checkTest = true;
	bool answerTest1 = true;
	char stringTest1[13] = "{[()()][]()}";
	bool myAnswerTest1 = checkBalance(stringTest1);
	checkTest = checkAnswer(myAnswerTest1, answerTest1, checkTest);

	bool answerTest2 = false;
	char stringTest2[21] = "({}({[()(()][]()}))";
	bool myAnswerTest2 = checkBalance(stringTest2);
	checkTest = checkAnswer(myAnswerTest2, answerTest2, checkTest);
	return checkTest;
}

int main()
{

	if (!test())
	{
		return -1;
	}
	char string[100]{};
	printf("Input string:\n");
	scanf("%s", string);
	if (checkBalance(string))
	{
		printf("Balance is correct\n");
	}
	else
	{
		printf("Balance is not correct\n");
	}
	return 0;
}

