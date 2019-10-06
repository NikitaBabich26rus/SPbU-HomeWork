#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>


bool binSearch(int size, int value, int array[])
{
	int countLeft = 0;
	int countRight = size - 1;
	bool answer = false;
	while (countLeft <= countRight && !answer)
	{
		const int countMind = (countLeft + countRight) / 2;
		if (array[countMind] == value)
		{
			answer = true;
		}
		if (array[countMind] < value)
		{
			countLeft = countMind + 1;
		}
		else
		{
			countRight = countMind - 1;
		}
	}
	return answer;
}

void input(int size, int array[])
{
	for (int i = 0; i < size; i++)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
}

void qsort(int countLeft, int countRight, int array[])
{
	int value = array[(countLeft + countRight) / 2];
	for (int i = countLeft, j = countRight; i < j;)
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
			if (i - countLeft + 1 >= 3)
			{
				qsort(countLeft, i, array);
			}
			if (countRight - j + 1 >= 3)
			{
				qsort(j + 1, countRight, array);
			}
		}
	}
}

bool searching(int size, int array[], int value)
{
	for (int i = 0; i < size; i++)
	{
		if (value == array[i])
		{
			return true;
		}
	}
	return false;
}

bool checkTests(int size, int array[], int checkArray[], int checkSize)
{
	int count = 0;
	for (int i = 0; i < checkSize; i++)
	{
		printf("%d ", binSearch(size, checkArray[i], array));
		printf("%d\n", searching(size, array, checkArray[i]));
		if (binSearch(size, checkArray[i], array) != searching(size, array, checkArray[i]))
		{
			return false;
		}
	}
	return true;
}

void ifTest(bool test)
{
	if (!test)
	{
		printf("Program error\n");
	}
	else
	{
		printf("Program is correct\n");
	}
}

void tests()
{
	const int size1 = 20;
	const int checkSize1 = 5;
	bool test = false;
	int checkArray1[checkSize1] = { 0, 2, 23323, 1, -779 };
	int testArray1[size1] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	input(size1, testArray1);
	qsort(0, size1 - 1, testArray1);
	test = checkTests(size1, testArray1, checkArray1, checkSize1);
	ifTest(test);

	const int size2 = 1;
	const int checkSize2 = 3;
	int checkArray2[checkSize2] = { -123, 0, -1213 };
	int testArray2[size2] = { -1213 };
	input(size2, testArray2);
	qsort(0, size2 - 1, testArray2);
	test = checkTests(size2, testArray2, checkArray2, checkSize2);
	ifTest(test);

	const int size3 = 100;
	const int checkSize3 = 12;
	int testArray3[size3]{};
	int checkArray3[checkSize3] = { 1, 12, 32, 2, 3, 4, 5, 6, 7, 8, 9, 78 };
	srand(time(nullptr));
	for (int i = 0; i < size3; i++)
	{
		testArray3[i] = rand() % 100;
	}
	input(size3, testArray3);
	qsort(0, size3 - 1, testArray3);
	test = checkTests(size3, testArray3, checkArray3, checkSize3);
	ifTest(test);
}


int main()
{
	printf("Tests:\n");
	tests();
	return 0;
}
