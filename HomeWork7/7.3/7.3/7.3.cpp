
#include "List.h"
#include <stdio.h>
#include <string.h>
#include "MergeSort.h"

int main()
{
	int size;
	List* list = createList();
	printf("Input size\n");
	scanf("%d", &size);
	for (int i = 0; i < size; i++)
	{
		char name[50]{};
		char number[50]{};
		printf("Input name : ");
		scanf("%s", name);
		printf("Input number : ");
		scanf("%s", number);
		push(list, name, number);
	}
	output(list);
	List* newList = mergeSort(list);
	output(newList);
	return 0;
}

