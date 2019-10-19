
#include <stdio.h>
#include <cstringt.h>
#include <stdlib.h>

const int sizeName = 30;
const int sizeNumber = 11;

struct Directory
{
	char name[sizeName];
	char number[sizeNumber];
};

void push (Directory array[], int size)
{
	printf("Input name\n");
	scanf("%s",  array[size].name);
	printf("Input number\n");
	scanf("%s", array[size].number);
}

void output(Directory array[], int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s ", array[i].name);
		printf("%s\n", array[i].number);
	}
}

void searchNumberByName(Directory array[], int size)
{
	char helpName[sizeName];
	printf("Input name\n");
	scanf("%s", helpName);
	for (int i = 0; i < size; i++)
	{
		if (strcmp(helpName, array[i].name) == 0)
		{
			printf("%s\n", array[i].number);
		}
	}
}

void searchNameByNumber(Directory array[], int size)
{
	char helpNumber[sizeNumber];
	printf("Input number\n");
	scanf("%s", helpNumber);
	for (int i = 0; i < size; i++)
	{
		if (strcmp(helpNumber, array[i].number) == 0)
		{
			printf("%s\n", array[i].name);
		}
	}
}

void saveInFile(Directory array[], int size)
{
	FILE* file = fopen("Directory.txt", "w");
	for (int i = 0; i < size; i++)
	{
		fprintf(file, "%s ", array[i].name);
		fprintf(file, "%s\n", array[i].number);
	}
	fclose(file);
}

int main()
{
	Directory array[100] = {};
	int size = 0;
	while (true)
	{
		printf("Input command\n");
		int command = 0;
		scanf("%d", &command);
		if (command == 0)
		{
			return 0;
		}
		if (command == 1)
		{
			push(array, size);
			size++;
		}
		if (command == 2)
		{
			output(array, size);
		}
		if (command == 3)
		{
			searchNumberByName(array, size);
		}
		if (command == 4)
		{
			searchNameByNumber(array, size);
		}
		if (command == 5)
		{
			saveInFile(array, size);
		}

	}
	return 0;
}

