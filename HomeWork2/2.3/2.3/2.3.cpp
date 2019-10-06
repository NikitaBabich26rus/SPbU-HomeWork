#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void bubble(int size, int array[]);

void sortingByCounting(int size, int array[]);

void output(int size, int array[]);

int main()
{
	int array[1000];
	int size = 0;
	int choice = 0;
	printf("If you want choice Bubble sort, Input 1\n");
	printf("If you want choice Sorting by counting, Input 0\n");
	scanf("%d", &choice);
	printf("Input size of array\n");
	scanf("%d", &size);
	printf("Input array\n");
	for (int i = 0; i < size; i++)
	{
		scanf("%d", &array[i]);
	}
	if (choice == 1)
	{
		bubble(size, array);
		output(size, array);
	}
	else
	{
		sortingByCounting(size, array);
		output(size, array);
	}
	return 0;
}


void bubble(int size, int array[])
{
	for (int i = 0; i < size; i++)
	{
		for (int j = size - 1; j > i; j--)
		{
			if (array[j] < array[j - 1])
			{
				int help = array[j];
				array[j] = array[j - 1];
				array[j - 1] = help;
			}
		}
	}
}

void sortingByCounting(int size, int array[])
{
	int minValue = array[0];
	int maxValue = array[0];
	for (int i = 0; i < size; i++)
	{
		if (array[i] <= minValue)
		{
			minValue = array[i];
		}
		if (array[i] >= maxValue)
		{
			maxValue = array[i];
		}
	}
	int helpSize = maxValue - minValue + 1;
	int counter = -minValue;
	int* helpArray = new int[helpSize + 1]{};
	for (int i = 0; i < size; i++)
	{
		helpArray[array[i] + counter]++;
	}
	int count = 0;
	for (int i = 0; i <= helpSize; i++)
	{
		for (int j = 0; j < helpArray[i]; j++)
		{
			array[count] = i - counter;
			count++;
		}
	}
	delete[] helpArray;
}

void output(int size, int array[])
{
	for (int i = 0; i < size; i++)
	{
		printf("%d ", array[i]);
	}
}