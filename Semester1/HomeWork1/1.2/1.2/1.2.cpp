
#include <stdio.h>
#include <stdlib.h>

int main()
{
	int a, b, count = 0;
	printf("Input values a and b");
	scanf("%d", &a);
	scanf("%d", &b);
	if (b == 0)
	{
		printf("Error");
		return 0;
	}
	int value_a = abs(a);
	int value_b = abs(b);
	while (value_a >= value_b)
	{
		value_a = value_a - value_b;
		count++;
	}
	if (value_a != 0 && a < 0 || b < 0)
	{
		count++;
	}
	if (a < 0 && b > 0)
	{
		printf("%d", -count);
	}
	else
	{
		printf("%d", count);
	}
	return 0;
}


