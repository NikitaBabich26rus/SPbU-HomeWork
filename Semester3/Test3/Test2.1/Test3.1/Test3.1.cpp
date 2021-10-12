#include "List.h"
#include <stdio.h>

bool test()
{
	int answerSize = 4;
	List* listTest = createList();
	List* newListTest = createList();
	int testArray[10] = { 1, 2, 3, 123, 14, 15, 16, 17, 1, 1 };
	for (int i = 0; i < 10; i++)
	{
		push(listTest, testArray[i]);
	}
	int lastPosition = 0;
	int position = algotithm(listTest, &lastPosition);
	pustToNewListFromOldList(listTest, newListTest, position, &lastPosition);
	if (checkSort(newListTest) && (lastPosition - position + 1) == answerSize)
	{
		return true;
	}
	return false;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	List* list = createList();
	int sizeList = 0;
	printf("Input size of list : ");
	scanf("%d", &sizeList);
	printf("Input values of list : ");
	for (int i = 0; i < sizeList; i++)
	{
		int value;
		scanf("%d", &value);
		push(list, value);
	}
	int lastPosition = 0;
	int position = algotithm(list, &lastPosition);
	List* newList = createList();
	pustToNewListFromOldList(list, newList, position, &lastPosition);
	printf("Your list : ");
	outputList(newList);
}

