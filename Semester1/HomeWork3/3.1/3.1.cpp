
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

void insertionSort(int countLeft, int countRight, int array[])
{
	for (int i = countLeft; i <= countRight; i++)
	{
		const int value = array[i];
		int j = i;
		for (; j > countLeft && array[j - 1] > value; j--)
		{
			array[j] = array[j - 1];
		}
		array[j] = value;
	}
}




void output(int size, int array[])
{
	for (int i = 0; i < size; i++)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
}

void qsort(int countLeft, int countRight, int array[])
{
	int arrayHelp[3]{};
	arrayHelp[0] = array[countLeft];
	arrayHelp[1] = array[countRight];
	arrayHelp[2] = array[(countLeft + countRight) / 2];
	insertionSort(0, 2, arrayHelp);
	const int value = arrayHelp[1];
	for (int i = countLeft, j = countRight; i != j;)
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
		if (i == j)
		{
			if (countLeft - i + 1 < 10)
			{
				insertionSort(countLeft, i, array);
			}
			else
			{
				qsort(countLeft, i, array);
			}
			if (j - countRight + 1 < 10)
			{
				insertionSort(j, countRight, array);
			}
			else
			{
				qsort(j, countRight, array);
			}
		}
	}
}

bool checkTests(int size, int array[])
{
	qsort(0, size - 1, array);
	if (size == 1)
	{
		return true;
	}
	for (int i = 0; i < size - 1; i++)
	{
		if (array[i] > array[i + 1])
		{
			return !(array[i] > array[i + 1]);
		}
	}
}


void ifTest(bool test)
{
	if (test)
	{
		printf("Program is correct\n");
	}
	else
	{
		printf("Program error\n");
	}
}

void tests()
{
	bool test = false;
	const int sizeTest1 = 1;
	int testArray1[sizeTest1] = { 768638219 };
	output(sizeTest1, testArray1);
	test = checkTests(sizeTest1, testArray1);
	output(sizeTest1, testArray1);
	ifTest(test);
	const int sizeTest2 = 10;
	int testArray2[sizeTest2] = { -1231, -32, -3213, 2332, 445, 0, 5, 3131, 44, 44 };
	output(sizeTest2, testArray2);
	test = checkTests(sizeTest2, testArray2);
	output(sizeTest2, testArray2);
	ifTest(test);
	const int sizeTest3 = 10000;
	int testArray3[sizeTest3];
	srand(time(nullptr));
	for (int i = 0; i < sizeTest3; i++)
	{
		testArray3[i] = rand() % 10;
	}
	output(sizeTest3, testArray3);
	test = checkTests(sizeTest3, testArray3);
	output(sizeTest3, testArray3);
	ifTest(test);
}

int main()
{
	printf("Tests:\n");
	tests();
	return 0;
}