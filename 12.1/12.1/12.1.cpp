#include <stdio.h>
#include <locale.h>
#include "Matiasevich.h"

const int sizeOfString = 100000;

bool test()
{
	bool test = true;
	char stringTest1[10]{ "abcdabce" };
	char obrazTest1[10]{ "abce" };
	if (Matiasevich(stringTest1, obrazTest1) != 4)
	{
		test = false;
	}
	char stringTest2[10]{ "abcdacde" };
	char obrazTest2[10]{ "cd" };
	if (Matiasevich(stringTest2, obrazTest2) != 2)
	{
		test = false;
	}
	char stringTest3[10]{ "aaaaaaaa" };
	char obrazTest3[10]{ "gghg" };
	if (Matiasevich(stringTest3, obrazTest3) != -1)
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
	char obraz[sizeOfString];
	printf("Введите образ : ");
	scanf("%s", obraz);

	FILE* file = fopen("Input.txt", "r");

	char string[sizeOfString]{};
	for (int i = 0; !feof(file); i++)
	{
		fscanf(file, "%c", &string[i]);
	}
	fclose(file);

	printf("Первое вхождение : ");
	printf("%d", Matiasevich(string, obraz));
	return 0;
}

