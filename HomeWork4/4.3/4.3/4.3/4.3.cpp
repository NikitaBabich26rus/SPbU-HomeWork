
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

const int sizeName = 30;
const int sizeNumber = 11;

struct Directory
{
	char name[sizeName];
	char number[sizeNumber];
};

void push(Directory array[], int size, char name[], char number[])
{
	strcpy(array[size].name, name);
	strcpy(array[size].number, number);
}

void outputDirectory(Directory array[], int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s ", array[i].name);
		printf("%s\n", array[i].number);
	}
}

void searchNumberByName(Directory array[], int size, char helpName[], char answer[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(helpName, array[i].name) == 0)
		{
			printf("Found number : ");
			printf("%s\n", array[i].number);
			strcpy(answer, array[i].number);
		}
	}
}

void searchNameByNumber(Directory array[], int size, char helpNumber[], char answer[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(helpNumber, array[i].number) == 0)
		{
			printf("Found name : ");
			printf("%s\n", array[i].name);
			strcpy(answer, array[i].name);
		}
	}
}

void saveInFile(Directory array[], int size)
{
	FILE* file = fopen("Directory.txt", "w");
	for (int i = 0; i < size; i++)
	{
		fprintf(file, "%s\n", array[i].name);
		fprintf(file, "%s\n", array[i].number);
	}
	fclose(file);
}

void outputString(char array[])
{
	printf("%s\n", array);
}

void  checkTest(char answer[], char myAnswer[])
{
	if (strcmp(answer, myAnswer) == 0)
	{
		printf("Program is correct\n");
	}
	else
	{
		printf("Program error\n");
	}
}

void checkDirectory(Directory array[], int size)
{
	FILE* file = fopen("Directory.txt", "r");
	bool check = true;
	for (int i = 0; i < size; i++)
	{
		char arrayHelpName[sizeName];
		char arrayHelpNumber[sizeNumber];
		fscanf(file, "%s", arrayHelpName);
		fscanf(file, "%s", arrayHelpNumber);
		if (strcmp(arrayHelpName, array[i].name) != 0 || strcmp(arrayHelpNumber, array[i].number) != 0)
		{
			check = false;
		}
	}
	if (check)
	{
		printf("Program is correct\n");
	}
	else
	{
		printf("Program error\n");
	}
	fclose(file);
}

void test()
{
	Directory array[100] = {};
	int size = 0;
	printf("Input command\n");
	int command = 1;
	printf("%d\n", command);
	printf("Input name\n");
	char name1[sizeName] = "aaaa";
	outputString(name1);
	printf("Input number\n");
	char number1[sizeNumber] = "1111";
	printf("%s\n", number1);
	push(array, size, name1, number1);
	size++;

	printf("\n");
	printf("Input command\n");
	command = 1;
	printf("%d\n", command);
	printf("Input name\n");
	char name2[sizeName] = "bbbb";
	outputString(name2);
	printf("Input number\n");
	char number2[sizeNumber] = "2222";
	printf("%s\n", number2);
	push(array, size, name2, number2);
	size++;

	printf("\n");
	printf("Input command\n");
	command = 2;
	printf("%d\n", command);
	printf("Directory:\n");
	outputDirectory(array, size);

	printf("\n");
	printf("Input command\n");
	command = 3;
	char answer1[sizeNumber] = "2222";
	printf("%d\n", command);
	printf("Input name to search for the number\n");
	char helpName[sizeName] = "bbbb";
	char myAnswerNumber[sizeNumber];
	searchNumberByName(array, size, helpName, myAnswerNumber);
	checkTest(answer1, myAnswerNumber);

	printf("\n");
	printf("Input command\n");
	command = 4;
	char answer2[sizeName] = "aaaa";
	printf("%d\n", command);
	printf("Input number to search for the name\n");
	char helpNumber[sizeNumber] = "1111";
	char myAnswerName[sizeName];
	searchNameByNumber(array, size, helpNumber, myAnswerName);
	checkTest(answer2, myAnswerName);

	printf("\n");
	printf("Input command\n");
	command = 5;
	printf("%d\n", command);
	saveInFile(array, size);
	printf("Directory is saved in file\n");
	checkDirectory(array, size);
}

int main()
{
	test();
	return 0;
}