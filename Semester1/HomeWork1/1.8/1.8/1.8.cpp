
#include <stdio.h>
#include <stdlib.h>

int main()
{
	int size, count = 0;
	printf("Input size of array");
	scanf("%d", &size);
	for (int i = 0; i < size; i++)
	{
		int value;
		scanf("%d", &value);
		if (!value)
		{
			count++;
		}
	}
	printf("%d", count);
	return 0;
}


