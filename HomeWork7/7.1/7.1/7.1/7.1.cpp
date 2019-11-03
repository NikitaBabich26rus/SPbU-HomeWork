
#include <stdio.h>
#include <locale.h>
#include "List.h"

bool test()
{
	bool checkTest = true;
	List* test = createList();
	push(test, 5);
	push(test, 3);
	push(test, 112);
	if (checkElement(test, -123))
	{
		checkTest = false;
	}
	if (checkElement(test, -12))
	{
		checkTest = false;
	}
	if (!checkSort(test))
	{
		checkTest = false;
	}
	deleteElement(test, 112);
	deleteElement(test, 3);
	if (!checkElement(test, 5))
	{
		checkTest = false;
	}
	if (!checkSort(test))
	{
		checkTest = false;
	}
	deleteList(test);
	return checkTest;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	List* list = createList();
	while (true)
	{
		int command = 0;
		printf("Input command : ");
		scanf("%d", &command);
		if (command == 0)
		{
			return 0;
		}
		if (command == 1)
		{
			int value = 0;
			printf("Input value : ");
			scanf("%d", &value);
			push(list, value);
		}
		if (command == 2)
		{
			int value = 0;
			printf("Input value : ");
			scanf("%d", &value);
			deleteElement(list, value);
		}
		if (command == 3)
		{
			printf("Your list : ");
			outputList(list);
			printf("\n");
		}
	}
	deleteList(list);
	return 0;
}

