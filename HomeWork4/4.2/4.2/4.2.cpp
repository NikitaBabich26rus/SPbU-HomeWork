
#include <stdio.h>
#include "qsort.h"
#include <stdlib.h>
#include <math.h>
#include <time.h>

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
		else
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
	int sizeTest = 0;
	int answer = 0;
	FILE * file = fopen("Test.txt", "r");
	for (int count = 0; count < 3; count++)
	{
		fscanf(file, "%d", &sizeTest);
		fscanf(file, "%d", &answer);
		int *testArray = new int[sizeTest];
		for (int i = 0; i < sizeTest; i++)
		{
			fscanf(file, "%d", &testArray[i]);
		}
		output(sizeTest, testArray);
		qsort(0, sizeTest - 1, testArray);
		checkTests(searching(sizeTest, testArray), answer);
		delete[]testArray;
	}
	fclose(file);
}


int main()
{
	test();	
	return 0;
}