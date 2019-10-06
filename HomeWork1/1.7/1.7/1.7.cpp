
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
	int value;
	printf("Input value\n");
	scanf("%d", &value);
	for (int i = 2; i <= value; i++)
	{
		double double_x = i;
		int int_x = i;
		for (int j = 1; j <= sqrt(double_x); j++)
		{
			if (int_x % j == 0 && j != 1)
			{
				break;
			}
			if (j + 1 > sqrt(double_x))
			{
				printf("%d ", int_x);
			}
		}
	}
	return 0;
}




