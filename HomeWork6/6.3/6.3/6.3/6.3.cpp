
#include <stdio.h>
#include "Stack.h"
#include <string.h>

int pushValue(char answer[], int count, char value)
{
	answer[count] = value;
	count++;
	answer[count] = ' ';
	count++;
	return count;
}

bool operators1(char value)
{
	return value == '/' || value == '*' || value == '-' || value == '+';
}

bool operators2(char value)
{
	return value == '/' || value == '*';
}

int algorithmDijkstra(Stack** head, char value, int count, char answer[])
{
	if (value <= '9' && value >= '0')
	{
		count = pushValue(answer, count, value);
	}
	if (value == '+' || value == '-')
	{
		while (!empty(head) && operators1((*head)->value))
		{
			count = pushValue(answer, count, pop(head));
		}
		push(value, head);
	}
	if (value == '/' || value == '*')
	{
		while (!empty(head) && operators2((*head)->value))
		{
			count = pushValue(answer, count, pop(head));
		}
		push(value, head);
	}
	if (value == '(')
	{
		push(value, head);
	}
	if (value == ')')
	{
		while ((*head)->value != '(')
		{
			count = pushValue(answer, count, (*head)->value);
			pop(head);
		}
		pop(head);
	}
	return count;
}

int checkString(char string[], char answer[])
{
	Stack* head = nullptr;
	int count = 0;
	for (int i = 0; string[i] != '\0'; i++)
	{
		if (string[i] != ' ')
		{
			count = algorithmDijkstra(&head, string[i], count, answer);
		}
	}
	while (head != nullptr)
	{
		count = pushValue(answer, count, head->value);
		Stack* newHead = head->next;
		delete head;
		head = newHead;
	}
	count--;
	deleteStack(&head);
	return count;
}

bool checkTest(char myAnswer[], char answer[], int size)
{
	for (int i = 0; i < size; i++)
	{
		if (myAnswer[i] != answer[i])
		{
			return false;
		}
	}
	return true;
}

bool tests()
{
	bool checkTest1 = false;
	char answerTest1[18] = "1 2 + 4 8 + * 3 /";
	char stringTest1[26] = "( 1 + 2 ) * ( 4 + 8 ) / 3";
	char myAnswerTest1[30]{};
	const int size = checkString(stringTest1, myAnswerTest1);
	checkTest1 = checkTest(myAnswerTest1, answerTest1, size);

	bool checkTest2 = false;
	char answerTest2[26] = "1 3 + 4 2 - * 9 9 4 - * /";
	char stringTest2[45] = "( ( 1 + 3 ) * ( 4 - 2 ) ) / ( 9 * ( 9 - 4 ))";
	char myAnswerTest2[30]{};
	const int size2 = checkString(stringTest2, myAnswerTest2);
	checkTest2 = checkTest(myAnswerTest2, answerTest2, size2);

	return checkTest1 && checkTest2;
}

int main()
{
	if (!tests())
	{
		return -1;
	}
	char string[100]{};
	char answer[100]{};
	printf("Input string\n");
	fgets(string, 100, stdin);
	const int size = checkString(string, answer);
	printf("%s\n", answer);
	return 0;
}
