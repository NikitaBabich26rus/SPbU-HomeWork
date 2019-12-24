
#include <stdio.h>
#include <string.h>
#include "Dka.h"
#include <locale.h>

bool tests()
{
	char string1[sizeOfString]{ "123.13E+1312" };
	char string2[sizeOfString]{ "123.13E+1ff2" };
	char string3[sizeOfString]{ "123E1123" };
	char string4[sizeOfString]{ "123,13E-12313" };
	bool test = true;
	if (!analyzer(string1))
	{
		test = false;
	}
	if (analyzer(string2))
	{
		test = false;
	}
	if (!analyzer(string3))
	{
		test = false;
	}
	if (!analyzer(string4))
	{
		test = false;
	}
	return test;
}

int main()
{
	if (!tests())
	{
		return -1;
	}

	setlocale(LC_ALL, "Russian");

	char string[sizeOfString];
	printf("Введите строку : ");
	scanf("%s", string);
	if (analyzer(string))
	{
		printf("Данная строка является вещественным числом");
	}
	else
	{
		printf("Данная строка не является вещественным числом");
	}
	return 0;
}

