
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>


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


int searching(int size, int array[])
{
	int answerValue = array[0];
	int count = 1;
	int answer = 1;
	for (int i = 0; i < size - 1; i++)
	{
		if (array[i] == array[i + 1])
		{
			count++;
		}
		if (array[i] != array[i + 1])
		{
			if (count > answer)
			{
				answer = count;
				answerValue = array[i];
			}
			count = 1;
		}
		if (array[i] == array[i + 1] && i + 1 == size - 1)
		{
			if (count > answer)
			{
				answer = count;
				answerValue = array[i];
			}
		}
	}
	return answerValue;
}

void checkTests(int myAnswer, int trueAnswer)
{
	if (myAnswer == trueAnswer)
	{
		printf("Program is correct\n");
	}
	else
	{
		printf("Program error\n");
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


void test()
{
	const int sizeTest1 = 1;
	const int answer1 = 768638219;
	int testArray1[sizeTest1] = { 768638219 };
	output(sizeTest1, testArray1);
	qsort(0, sizeTest1 - 1, testArray1);
	checkTests(searching(sizeTest1, testArray1), answer1);

	const int sizeTest2 = 10;
	const int answer2 = 44;
	int testArray2[sizeTest2] = { -1231, -32, -3213, 2332, 445, 0, 5, 3131, 44, 44 };
	output(sizeTest2, testArray2);
	qsort(0, sizeTest2 - 1, testArray2);
	checkTests(searching(sizeTest2, testArray2), answer2);

	const int helpSizeTest3 = 20;
	const int sizeTest3 = 10000;
	const int answer3 = 5;
	int testArray3[sizeTest3]{};
	int HelpTestArray3[helpSizeTest3] = {2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};
	int count = 0;
	for (int i = 0; i < sizeTest3 / helpSizeTest3; i++)
	{
		for (int j = 0; j < helpSizeTest3; j++)
		{
			testArray3[count] = HelpTestArray3[j];
			count++;
		}
	}
	output(sizeTest3, testArray3);
	checkTests(searching(sizeTest3, testArray3), answer3);
}


int main()
{
	test();
	return 0;
}