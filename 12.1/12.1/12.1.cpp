#include <stdio.h>
#include <locale.h>
#include "Matiasevich.h"

const int sizeOfString = 5000;

bool test()
{
	bool test = true;
	char stringTest1[10]{ "abcdabce" };
	char stringForSearchingTest1[10]{ "abce" };
	if (matiasevich(stringTest1, stringForSearchingTest1) != 4)
	{
		test = false;
	}
	char stringTest2[10]{ "abcdacde" };
	char stringForSearchingTest2[10]{ "cd" };
	if (matiasevich(stringTest2, stringForSearchingTest2) != 2)
	{
		test = false;
	}
	char stringTest3[10]{ "aaaaaaaa" };
	char stringForSearchingTest3[10]{ "gghg" };
	if (matiasevich(stringTest3, stringForSearchingTest3) != -1)
	{
		test = false;
	}
	return test;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Russian");
	char stringForSearching[sizeOfString];
	printf("Введите образ : ");
	scanf("%s", stringForSearching);

	FILE* file = fopen("Input.txt", "r");

	char string[sizeOfString]{};
	for (int i = 0; !feof(file); i++)
	{
		fscanf(file, "%c", &string[i]);
	}
	fclose(file);

	printf("Первое вхождение : ");
	printf("%d", matiasevich(string, stringForSearching));
	return 0;
}

