
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

void searchNumberByName(Directory array[], int size, char name[], char answer[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(name, array[i].name) == 0)
		{
			printf("Found number : ");
			printf("%s\n", array[i].number);
			strcpy(answer, array[i].number);
		}
	}
}

void searchNameByNumber(Directory array[], int size, char number[], char answer[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(number, array[i].number) == 0)
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

void checkTest(char answer[], char myAnswer[])
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
	Directory arrayTest[10]{};
	int size = 0;
	int command = 1;
	printf("%d\n", command);
	printf("Input name\n");
	char name1[sizeName] = "aaaa";
	outputString(name1);
	printf("Input number\n");
	char number1[sizeNumber] = "1111";
	printf("%s\n", number1);
	push(arrayTest, size, name1, number1);
	size++;

	printf("\n");
	command = 1;
	printf("%d\n", command);
	printf("Input name\n");
	char name2[sizeName] = "bbbb";
	outputString(name2);
	printf("Input number\n");
	char number2[sizeNumber] = "2222";
	printf("%s\n", number2);
	push(arrayTest, size, name2, number2);
	size++;

	printf("\n");
	command = 2;
	printf("%d\n", command);
	printf("Directory:\n");
	outputDirectory(arrayTest, size);

	printf("\n");
	command = 3;
	char answer1[sizeNumber] = "2222";
	printf("%d\n", command);
	printf("Input name to search for the number\n");
	char helpName[sizeName] = "bbbb";
	char myAnswerNumber[sizeNumber];
	searchNumberByName(arrayTest, size, helpName, myAnswerNumber);
	checkTest(answer1, myAnswerNumber);

	printf("\n");
	command = 4;
	char answer2[sizeName] = "aaaa";
	printf("%d\n", command);
	printf("Input number to search for the name\n");
	char helpNumber[sizeNumber] = "1111";
	char myAnswerName[sizeName];
	searchNameByNumber(arrayTest, size, helpNumber, myAnswerName);
	checkTest(answer2, myAnswerName);

	printf("\n");
	command = 5;
	printf("%d\n", command);
	saveInFile(arrayTest, size);
	printf("Directory is saved in file\n");
	checkDirectory(arrayTest, size);
	printf("\n");
}

int main()
{
	Directory array[100];
	test();
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
			char name[sizeName]{};
			char number[sizeNumber]{};
			printf("Input name\n");
			scanf("%s", name);
			printf("Input number\n");
			scanf("%s", number);
			push(array, size, name, number);
			size++;
		}
		if (command == 2)
		{
			outputDirectory(array, size);
		}
		if (command == 3)
		{
			char answer[sizeNumber]{};
			char name[sizeName]{};
			printf("Input name to search for the number\n");
			scanf("%s", name);
			searchNumberByName(array, size, name, answer);

		}
		if (command == 4)
		{
			char answer[sizeName]{};
			char number[sizeNumber]{};
			printf("Input number to search for the name\n");
			scanf("%s", number);
			searchNameByNumber(array, size, number, answer);
		}
		if (command == 5)
		{
			saveInFile(array, size);
		}
	}
	return 0;
}