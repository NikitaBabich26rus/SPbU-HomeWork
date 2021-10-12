
#include <stdio.h>
#include <locale>

const int size = sizeof(int) * 8;

void binary(int value, bool array[])
{
	int bit = 1;
	for (int i = size - 1; i >= 0; i--)
	{
		(value & bit) ? array[i] = 1 : array[i] = 0;
		bit = bit << 1;
	}
}

int denary(bool array[])
{
	int answer = 0;
	int exponent = 1;
	for (int i = size - 1; i >= 0; i--)
	{
		answer += exponent * array[i];
		exponent *= 2;
	}
	return answer;
}

void sum(bool array1[], bool array2[], bool answerArray[])
{
	bool count = false;
	for (int i = size - 1; i >= 0; i--)
	{
		if ((array1[i] && array2[i] && count) || (array1[i] != array2[i] && !count))
		{
			answerArray[i] = 1;
		}
		if ((array1[i] && array2[i] && !count) || (array1[i] != array2[i] && count))
		{
			count = true;
		}
		if (!array1[i] && !array2[i] && count)
		{
			answerArray[i] = 1;
			count = false;
		}
	}
}

void checkTests(int answer, int myAnswer)
{
	if (answer == myAnswer)
	{
		printf("Программа работает правильно\n");
	}
	else
	{
		printf("Программа работает неправильно\n");
	}
}

void output(bool array[])
{
	for (int i = 0; i < 32; i++)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
}

void tests()
{
	const int answerTest1 = 7;
	bool array1Test1[size]{};
	bool array2Test1[size]{};
	bool answerArrayTest1[size]{};
	const int value1Test1 = 3;
	printf("Первое число\n");
	printf("%d\n", value1Test1);
	binary(value1Test1, array1Test1);
	output(array1Test1);
	const int value2Test1 = 4;
	printf("Второе число\n");
	printf("%d\n", value2Test1);
	binary(value2Test1, array2Test1);
	output(array2Test1);
	sum(array1Test1, array2Test1, answerArrayTest1);
	printf("Сумма чисел\n");
	output(answerArrayTest1);
	const int myAnswerTest1 = denary(answerArrayTest1);
	printf("%d\n", myAnswerTest1);
	checkTests(answerTest1, myAnswerTest1);
	printf("\n");
	
	const int answerTest2 = 0;
	bool array1Test2[size]{};
	bool array2Test2[size]{};
	bool answerArrayTest2[size]{};
	const int value1Test2 = -100;
	printf("Первое число\n");
	printf("%d\n", value1Test2);
	binary(value1Test2, array1Test2);
	output(array1Test2);
	const int value2Test2 = 100;
	printf("Второе число\n");
	printf("%d\n", value2Test2);
	binary(value2Test2, array2Test2);
	output(array2Test2);
	sum(array1Test2, array2Test2, answerArrayTest2);
	printf("Сумма чисел\n");
	output(answerArrayTest2);
	const int myAnswerTest2 = denary(answerArrayTest2);
	printf("%d\n", myAnswerTest2);
	checkTests(answerTest2, myAnswerTest2);
	printf("\n");

	const int answerTest3 = -1188977;
	bool array1Test3[size]{};
	bool array2Test3[size]{};
	bool answerArrayTest3[size]{};
	const int value1Test3 = -187979;
	printf("Первое число\n");
	printf("%d\n", value1Test3);
	binary(value1Test3, array1Test3);
	output(array1Test3);
	const int value2Test3 = -1000998;
	printf("Второе число\n");
	printf("%d\n", value2Test3);
	binary(value2Test3, array2Test3);
	output(array2Test3);
	sum(array1Test3, array2Test3, answerArrayTest3);
	printf("Сумма чисел\n");
	output(answerArrayTest3);
	const int myAnswerTest3 = denary(answerArrayTest3);
	printf("%d\n", myAnswerTest3);
	checkTests(answerTest3, myAnswerTest3);
	printf("\n");
}

int main()
{
	setlocale(LC_CTYPE, "rus");
	tests();
	return 0;
}

