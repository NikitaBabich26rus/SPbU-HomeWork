#include <stdio.h>
#include "Tree.h"
#include <locale.h>
#include <cstring>

bool test()
{
	Tree* tree = create();
	int keyTest1 = 5;
	char wordTest1[sizeOfWord] = "a";
	push(tree, keyTest1, wordTest1);
	int keyTest2 = 19;
	char wordTest2[sizeOfWord] = "b";
	push(tree, keyTest2, wordTest2);
	int keyTest3 = 25;
	char wordTest3[sizeOfWord] = "c";
	push(tree, keyTest3, wordTest3);
	int keyTest4 = 9;
	char wordTest4[sizeOfWord] = "d";
	push(tree, keyTest4, wordTest4);
	int keyTest5 = 14;
	char wordTest5[sizeOfWord] = "e";
	push(tree, keyTest5, wordTest5);
	int keyTest6 = 16;
	char wordTest6[sizeOfWord] = "f";
	push(tree, keyTest6, wordTest6);
	int keyTest7 = 15;
	char wordTest7[sizeOfWord] = "gg";
	push(tree, keyTest7, wordTest7);
	deleteElement(tree, 19);
	bool test = true;
	if (checkKeyInTree(tree, 19) == true)
	{
		test = false;
	}
	if (checkWordInTree(tree, 19) != nullptr)
	{
		test = false;
	}
	if (checkKeyInTree(tree, 5) == false)
	{
		test = false;
	}
	if (checkKeyInTree(tree, 9) == false)
	{
		test = false;
	}
	if (checkKeyInTree(tree, 25) == false)
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
	setlocale(LC_ALL, "Rus");
	Tree* tree = create();
	printf("Если вы хотите добавить новое слово по ключу, введите 1\n");
	printf("Если вы хотите получить значение по заданному ключу из словаря, введите 2\n");
	printf("Если вы хотите проверить наличие заданного ключа в словаре, введите 3\n");
	printf("Если вы хотите удалить заданный ключ и связанное с ним значение из словаря, введите 4\n");
	printf("Если вы хотите выйти, введите 0\n");
	while(true)
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
			push(tree, key, word);
		}
		if (command == 2)
		{
			printf("Введите ключ : ");
			int key = 0;
			scanf("%d", &key);

			if (!checkKeyInTree(tree, key))
			{
				printf("Данного слова нет в словаре\n");
			}
			else
			{
				char helpWord[sizeOfWord]{};
				strcpy(helpWord, checkWordInTree(tree, key));
				printf("Ваше слово : ");
				printf("%s\n", helpWord);
			}
		}
		if (command == 3)
		{
			printf("Введите ключ : ");
			int key = 0;
			scanf("%d", &key);
			if (!checkKeyInTree(tree, key))
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
			deleteElement(tree, key);
		}
		if (command == 0)
		{
			deleteTree(tree);
			return 0;
		}
	}
}
