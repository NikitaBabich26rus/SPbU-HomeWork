
#include <stdio.h>
#include "HashTable.h"
#include <locale.h>
#include "List.h"

bool test()
{
	HashTable* table = createHashTable(3);
	char str1[10]{ "a" };
	char str2[10]{ "c" };
	char str3[10]{ "a" };
	char str4[10]{ "c" };
	char str5[10]{ "d" };
	table = addToTable(table, str1, 1);
	table = addToTable(table, str2, 1);
	table = addToTable(table, str3, 1);
	table = addToTable(table, str4, 1);
	table = addToTable(table, str5, 1);
	bool test = true;
	if (!containsInTable(table, str1))
	{
		test = false;
	}
	if (!containsInTable(table, str2))
	{
		test = false;
	}
	if (!containsInTable(table, str5))
	{
		test = false;
	}
	deleteTable(table);
	return test;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Russian");
	HashTable* table = createHashTable(3);
	FILE* file = fopen("Input.txt", "r");

	while (!feof(file))
	{
		char word[sizeOfWord]{};
		fscanf(file, "%s", word);
		table = addToTable(table, word, 1);
	}

	outputTable(table);
	printf("\n");
	outputResultOfProgram(table);
	deleteTable(table);
	return 0;
}