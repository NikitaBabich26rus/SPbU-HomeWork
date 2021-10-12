
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int array[10000];

void MrSwaper(int size, int count_r, int count_l)
{
	for (int i = 0; i < size / 2; i++)
	{
		int help = array[count_r];
		array[count_r] = array[count_l];
		array[count_l] = help;
		count_l++;
		count_r--;
	}
}

int main()
{
	int n, m;
	printf("Input values of n and m");
	scanf("%d", &n);
	scanf("%d", &m);
	for (int i = 0; i < n + m; i++)
	{
		scanf("%d", &array[i]);
	}
	MrSwaper(n, n - 1, 0);
	MrSwaper(m, n + m - 1, n);
	MrSwaper(n + m, n + m - 1, 0);
	for (int i = 0; i < n + m; i++)
	{
		printf("%d ", array[i]);
	}
	return 0;
}


