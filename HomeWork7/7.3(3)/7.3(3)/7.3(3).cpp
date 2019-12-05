#include "List.h"
#include <stdio.h>
#include <string.h>
#include "MergeSort.h"
#include <locale.h>

bool test()
{
	FILE* file = fopen("Test.txt", "r");
	List* list = createList();
	while (!feof(file))
	{
		char name[sizeOfString]{};
		char number[sizeOfString]{};
		fscanf(file, "%s", name);
		fscanf(file, "%s", number);
		push(list, name, number);
	}
	fclose(file);
	list = mergeSort(list);
	bool result = checkSort(list);
	deleteList(list);
	return result;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Rus");
	int choice = 0;
	printf("Для сортировки по имени введите 1, по номеру ввведите 0\n");
	scanf("%d", &choice);
	List* list = createList();
	FILE* file = fopen("Input.txt", "r");
	while (!feof(file))
	{
		char name[sizeOfString]{};
		char number[sizeOfString]{};
		fscanf(file, "%s", name);
		fscanf(file, "%s", number);
		if (choice == 1)
		{
			push(list, name, number);
		}
		else
		{
			push(list, number, name);
		}
	}
	fclose(file);
	list = mergeSort(list);
	output(list);
	deleteList(list);
	return 0;
}

