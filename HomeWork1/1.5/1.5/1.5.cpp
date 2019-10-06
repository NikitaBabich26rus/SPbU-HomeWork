
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
	int size;
	printf("Input size of array\n");
	scanf("%d", &size);
	char string[10000];
	int count1 = 0, count2 = 0;
	scanf("%s", &string);
	for (int i = 0; i < size; i++)
	{
		if (string[i] == '(')
		{
			count1++;
		}
		if (string[i] == ')')
		{
			count2++;
		}
		if (count2 > count1)
		{
			printf("Erorr");
			return 0;
		}
	}
	if (count1 == count2)
	{
		printf("Correctly");
	}
	else
	{
		printf("Erorr");
	}
	return 0;
}


