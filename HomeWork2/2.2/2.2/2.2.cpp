
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int fibonacciLong(int n)
{
	if (n <= 1)
	{
		return 1;
	}
	else
	{
		return fibonacciLong(n - 1) + fibonacciLong(n - 2);
	}
}


int fibonacciFast(int n)
{
	int fib2 = 0;
	int fib1 = 1;
	int answer = 1;
	for (int i = 1; i < n; i++)
	{
		fib2 = fib1;
		fib1 = answer;
		answer = fib2 + fib1;
	}
	return answer;
}

int main()
{
	int value;
	printf("Input value\n");
	scanf("%d", &value);
	printf("Recursive program\n");
	printf("%d\n", fibonacciLong(value));
	printf("Iterative program\n");
	printf("%d", fibonacciFast(value));
	return 0;
}