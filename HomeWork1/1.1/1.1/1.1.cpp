
#include <stdio.h>


int main()
{
	int x;
	printf("Input value x");
	scanf("%d", &x);
	int square_x1 = x * x;
	int square_x2 = square_x1 + 1;
	square_x1 = square_x1 + x;
	square_x1 = square_x1 * square_x2 + 1;
	printf("%d", square_x1);
	return 0;
}


