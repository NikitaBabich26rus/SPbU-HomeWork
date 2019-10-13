
#include <stdio.h>
#include <locale>

using namespace std;

void translation1(int value, int array[])
{
	int bit = 0b1;
	for (int j = 31; j >= 0; j--)
	{
		(value & bit) ? array[j] = 1 : array[j] = 0;
		bit = bit << 1;
	}
}

int  translation2(int array[])
{ 
	int answer = 0;
	int exponent = 1;
	for (int j = 31; j >= 0; j--)
	{
		answer += array[j] * exponent;
		exponent *= 2;
	}
	printf("%d\n", answer);
	return answer;
}

void output(int array[])
{
	for (int i = 0; i < 32; i++)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
}

void sum(int array1[], int array2[], int answer[])
{
	bool count = false;
	for (int i = 31; i >= 0; i--)
	{
		if (array1[i] && array2[i] && count)
		{
			answer[i] = 1;
		}
		if (array1[i] && array2[i] && !count)
		{
			count = true;
		}
		if (array1[i] != array2[i] && !count)
		{
			answer[i] = 1;
		}
		if (array1[i] != array2[i] && count)
		{
			count = true;
		}
		if (!array1[i] && !array2[i] && count)
		{
			count = false;
			answer[i] = 1;
		}
	}
}

void check(int answer, int MyAnswer)
{
	if (answer == MyAnswer)
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
	const int answerTest1 = 7;
	const int value1Test1 = 3;
	printf("First value\n");
	printf("%d\n", value1Test1);
	const int value2Test1 = 4;
	printf("Second value\n");
	printf("%d\n", value2Test1);
	int array1Test1[32]{};
	int array2Test1[32]{};
	int answerArrayTest1[32]{};
	translation1(value1Test1, array1Test1);
	translation1(value2Test1, array2Test1);
	output(array1Test1);
	output(array2Test1);
	sum(array1Test1, array2Test1, answerArrayTest1);
	printf("Sum of values\n");
	output(answerArrayTest1);
	const int myAnswerTest1 = translation2(answerArrayTest1);
	check(answerTest1, myAnswerTest1);
	printf("\n");
	
	const int answerTest2 = 0;
	const int value1Test2 = 100;
	printf("First value\n");
	printf("%d\n", value1Test2);
	const int value2Test2 = -100;
	printf("Second value\n");
	printf("%d\n", value2Test2);
	int array1Test2[32]{};
	int array2Test2[32]{};
	int answerArrayTest2[32]{};
	translation1(value1Test2, array1Test2);
	translation1(value2Test2, array2Test2);
	output(array1Test2);
	output(array2Test2);
	sum(array1Test2, array2Test2, answerArrayTest2);
	printf("Sum of values\n");
	output(answerArrayTest2);
	const int myAnswerTest2 = translation2(answerArrayTest2);
	check(answerTest2, myAnswerTest2);
	printf("\n");

	const int answerTest3 = -13255;
	int value1Test3 = -2132;
	printf("First value\n");
	printf("%d\n", value1Test3);
	const int value2Test3 = -11123;
	printf("Second value\n");
	printf("%d\n", value2Test3);
	int array1Test3[32]{};
	int array2Test3[32]{};
	int answerArrayTest3[32]{};
	translation1(value1Test3, array1Test3);
	translation1(value2Test3, array2Test3);
	output(array1Test3);
	output(array2Test3);
	sum(array1Test3, array2Test3, answerArrayTest3);
	printf("Sum of values\n");
	output(answerArrayTest3);
	const int myAnswerTest3 = translation2(answerArrayTest3);
	check(answerTest3, myAnswerTest3);
}

int main()
{
	tests();
	return 0;
}

