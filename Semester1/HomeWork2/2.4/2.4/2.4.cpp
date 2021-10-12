
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

void output(int size, int array[])
{
	for (int i = 0; i < size; i++)
	{
		printf("%d ", array[i]);
	}
}

int main()
{
	srand(time(nullptr));
	const int size = 10;
	int* array = new int[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = rand() % 10;
	}
	output(size, array);
	int value = array[0];
	for (int i = 0, j = size - 1; i != j;)
	{
		if (array[i] > array[j])
		{
			int const helpValue = array[i];
			array[i] = array[j];
			array[j] = helpValue;
		}
		if (array[i] < value)
		{
			i++;
		}
		else
		{
			j--;
		}
	}
	printf("\n");
	output(size, array);
	return 0;
}