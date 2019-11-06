#include "List.h"
#include <stdio.h>

int algorithm(int size, int count)
{
	List* list = createList();
	for (int i = 0; i < size; i++)
	{
		push(list, i + 1);
	}
	ListElement* parent = list->tail;
	while (parent != parent->next)
	{
		for (int i = 0; i < count - 1; i++)
		{
			parent = parent->next;
		}
		//outputList(list);
		//printf("\n");
		deleteElement(list, parent);
	}
	int answer = parent->value;
	delete parent;
	delete list;
	return answer;
}

bool test()
{
	bool checkTest = true;
	if (!(algorithm(2, 5) == 2))
	{
		checkTest = false;
	}
	if (!(algorithm(5, 3) == 4))
	{
		checkTest = false;
	}
	if (!(algorithm(50, 20) == 34))
	{
		checkTest = false;
	}
	return checkTest;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	int n = 0;
	printf("Input n : ");
	scanf("%d", &n);
	int m = 0;
	printf("Input m : ");
	scanf("%d", &m);
	printf("Your answer : ");
	printf("%d", algorithm(n, m));
	return 0;
}

