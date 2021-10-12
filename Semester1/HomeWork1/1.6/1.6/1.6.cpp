
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

void MrFinder(int count);
char str1[1000];
char str2[1000];
int size_str1, size_str2, answer = 0;

int main()
{
	printf("Input sizes of strings\n");
	scanf("%d", &size_str1);
	scanf("%d", &size_str2);
	printf("Input strings\n");
	scanf("%s", &str1);
	scanf("%s", &str2);
	for (int i = 0; i < size_str1; i++)
	{
		if (str1[i] == str2[0])
		{
			MrFinder(i);
		}
	}
	printf("%d", answer);
	return 0;
}

void MrFinder(int count)
{
	for (int j = 0; str1[count] == str2[j]; j++, count++)
	{
		if (j == size_str2 - 1)
		{
			answer++;
			break;
		}
	}
}

