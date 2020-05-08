
#include <stdio.h>
#include <locale.h>

const int size = 100;

struct Array
{
	bool numberOfstring = false;
	bool numberOfColumn = false;
};

bool checkAmount(int amount1, int amount2)
{
	return amount1 >= 100 || amount2 >= 100;
}

void checkArray(Array array[][size], int amountOfStrings, int amountOfColumns)
{
	for (int i = 0; i < amountOfStrings; i++)
	{
		for (int j = 0; j < amountOfColumns; j++)
		{
			if (array[i][j].numberOfColumn && array[i][j].numberOfstring)
			{
				printf("Седловая точка : ");
				printf("%d ", i);
				printf("%d\n", j);
			}
		}
	}
}

void getMaxInColumn(int array[][size], Array helpArray[][size], int amountOfString, int amountOfColumn)
{
	for (int j = 0; j < amountOfColumn; j++)
	{
		int max = array[0][j];
		for (int i = 0; i < amountOfString; i++)
		{
			if (array[i][j] > max)
			{
				max = array[i][j];
			}
		}
		for (int i = 0; i < amountOfString; i++)
		{
			if (array[i][j] == max)
			{
				helpArray[i][j].numberOfstring = true;
			}
		}
	}
}

void getMinInString(int array[][size], Array helpArray[][size], int amountOfString, int amountOfColumn)
{
	for (int i = 0; i < amountOfString; i++)
	{
		int min = array[i][0];
		for (int j = 0; j < amountOfColumn; j++)
		{
			if (min > array[i][j])
			{
				min = array[i][j];
			}
		}
		for (int j = 0; j < amountOfColumn; j++)
		{
			if (min == array[i][j])
			{
				helpArray[i][j].numberOfColumn = true;
			}
		}
	}
}


int main()
{
	setlocale(LC_ALL, "Russian");
	Array helpArray[size][size];
	int amountOfStrings = 0;
	int amountOfColumns = 0;
	printf("Ввод двумерного массива\n");
	printf("Введите n, количество строк. (n < 100) : ");
	scanf("%d", &amountOfStrings);
	printf("Введите m, количество столбцов. (m < 100) : ");
	scanf("%d", &amountOfColumns);
	if (checkAmount(amountOfColumns, amountOfStrings))
	{
		printf("Ошибка");
		return -1;
	}
	int array[size][size]{};
	printf("Введите массив\n");
	for (int i = 0; i < amountOfStrings; i++)
	{
		for (int j = 0; j < amountOfColumns; j++)
		{
			scanf("%d", &array[i][j]);
		}
	}
	getMaxInColumn(array, helpArray, amountOfStrings, amountOfColumns);
	getMinInString(array, helpArray, amountOfStrings, amountOfColumns);
	checkArray(helpArray, amountOfStrings, amountOfColumns);
}

