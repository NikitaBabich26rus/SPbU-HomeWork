
#include <stdio.h>
#include "List.h"

bool test()
{
	bool test = true;
	FILE* file = fopen("Test2.2.txt", "r");
	char testArray[4][2]{ "a",
						  "b",
						  "c",
						  "d" };
	List* oldList = createList();
	List* newList = createList();
	while (!feof(file))
	{
		char string[sizeOfString]{};
		fscanf(file, "%s", string);
		push(oldList, string);
	}
	pushToNewListFromOldList(newList, oldList);
	if (!checkTest(newList, testArray))
	{
		test = false;
	}
	deleteList(oldList);
	deleteList(newList);
	fclose(file);
	return true;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	FILE* file = fopen("Input2.2.txt", "r");
	List* oldList = createList();
	List* newList = createList();
	while (!feof(file))
	{
		char string[sizeOfString]{};
		fscanf(file, "%s", string);
		push(oldList, string);
	}

	pushToNewListFromOldList(newList, oldList);
	printf("Old list : \n");
	outputList(oldList);
	printf("New list : \n");
	outputList(newList);

	deleteList(oldList);
	deleteList(newList);
	fclose(file);
	return 0;
}
