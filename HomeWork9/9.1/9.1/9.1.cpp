
#include <stdio.h>
#include "AvlTree.h"
#include <locale.h>

bool test()
{
	Set* set = createSet();
	int keyTest1 = 5;
	char wordTest1[sizeOfWord] = "a";
	addElement(keyTest1, set, wordTest1);
	int keyTest2 = 19;
	char wordTest2[sizeOfWord] = "b";
	addElement(keyTest2, set, wordTest2);
	int keyTest3 = 25;
	char wordTest3[sizeOfWord] = "c";
	addElement(keyTest3, set, wordTest3);
	int keyTest4 = 9;
	char wordTest4[sizeOfWord] = "d";
	addElement(keyTest4, set, wordTest4);
	int keyTest5 = 14;
	char wordTest5[sizeOfWord] = "e";
	addElement(keyTest5, set, wordTest5);
	int keyTest6 = 16;
	char wordTest6[sizeOfWord] = "f";
	addElement(keyTest6, set, wordTest6);
	int keyTest7 = 15;
	char wordTest7[sizeOfWord] = "gg";
	addElement(keyTest7, set, wordTest7);
	deleteElement(19, set);
	bool test = true;
	if (isContained(19, set))
	{
		test = false;
	}
	if (getWord(19, set) != nullptr)
	{
		test = false;
	}
	if (!isContained(5, set))
	{
		test = false;
	}
	if (!isContained(9, set))
	{
		test = false;
	}
	if (!isContained(25, set))
	{
		test = false;
	}
	deleteSet(set);
	return test;
}

int main()
{
	if (!test())
	{
		return -1;
	}

	setlocale(LC_ALL, "Rus");

	Set* set = createSet();
	printf("Если вы хотите добавить новое слово по ключу, введите 1\n");
	printf("Если вы хотите получить значение по заданному ключу из словаря, введите 2\n");
	printf("Если вы хотите проверить наличие заданного ключа в словаре, введите 3\n");
	printf("Если вы хотите удалить заданный ключ и связанное с ним значение из словаря, введите 4\n");
	printf("Если вы хотите выйти, введите 0\n");
	while (true)
	{
		int command = 0;
		printf("Введите команду : ");
		scanf("%d", &command);

		if (command == 1)
		{
			printf("Введите ключ элемента : ");
			int key = 0;
			scanf("%d", &key);
			char word[sizeOfWord]{};
			printf("Введите слово : ");
			scanf("%s", word);
			addElement(key, set, word);
		}
		if (command == 2)
		{
			printf("Введите ключ : ");
			int key = 0;
			scanf("%d", &key);
			if (!isContained(key, set))
			{
				printf("Данного слова нет в словаре\n");
			}
			else
			{
				printf("Ваше слово : ");
				printf("%s\n", getWord(key, set));
			}
		}
		if (command == 3)
		{
			printf("Введите ключ : ");
			int key = 0;
			scanf("%d", &key);
			if (!isContained(key, set))
			{
				printf("Данный ключ не содержится в словаре\n");
			}
			else
			{
				printf("Данный ключ содержится в словаре\n");
			}
		}
		if (command == 4)
		{
			printf("Введите ключ : ");
			int key = 0;
			scanf("%d", &key);
			deleteElement(key, set);
		}
		if (command == 0)
		{
			deleteSet(set);
			return 0;
		}
	}
	return 0;
}

