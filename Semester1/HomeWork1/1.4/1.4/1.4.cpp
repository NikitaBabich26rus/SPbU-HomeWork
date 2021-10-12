
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
	int size_n = 14, size_m = 2;
	int array[14][2];
	int count = 0;
	for (int i = 0; i < size_n; i++)
	{
		if (i < 10)
		{
			count++;
			array[i][0] = count;
		}
		else
		{
			count--;
			array[i][0] = count;
		}
	}
	array[0][1] = 1;
	count = 1;
	int answer = 1;
	for (int i = 1; i < size_n; i++)
	{
		if (i >= 10)
		{
			array[i][1] = array[i][0] + array[i - 1][1] - count;
			count++;
		}
		else
		{
			array[i][1] = array[i][0] + array[i - 1][1];
		}
		answer += array[i][1] * array[i][1];
	}
	for (int i = 0; i < size_n; i++)
	{
		for (int j = 0; j < size_m; j++)
		{
			printf("%d ", array[i][j]);
		}
		printf("\n");
	}
	printf("%d", answer * 2);
	return 0;
}


