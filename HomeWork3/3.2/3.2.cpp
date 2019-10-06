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


bool checkTests(int size, int array[], bool test)
{
	for (int i = 0; i < size; i++)
	{
		if (!binSearch(size, array[i], array))
		{
			return false;
		}
		return true;
	}
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
	const int size1 = 1;
	bool test = false;
	int testArray1[size1] = { -23 };
	input(size1, testArray1);
	qsort(0, size1 - 1, testArray1);
	test = checkTests(size1, testArray1, test);
	ifTest(test);

	const int size2 = 12;
	int testArray2[size2] = { -1, 100, 2212, 312, 191, 100, 1881, 7, 323, 1, 1222, 2 };
	input(size2, testArray2);
	qsort(0, size2 - 1, testArray2);
	test = checkTests(size2, testArray2, test);
	ifTest(test);

	const int size3 = 10000;
	int testArray3[size3]{};
	srand(time(nullptr));
	for (int i = 0; i < size3; i++)
	{
		testArray3[i] = rand() % 100;
	}
	input(size3, testArray3);
	qsort(0, size3 - 1, testArray3);
	test = checkTests(size3, testArray3, test);
	ifTest(test);
}


int main()
{
	printf("Tests:\n");
	tests();
	return 0;
}
