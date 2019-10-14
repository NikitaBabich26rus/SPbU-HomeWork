#include "qsort.h"

using namespace std;

void qsort(int countLeft, int countRight, int array[])
{
	int value = array[(countLeft + countRight) / 2];
	for (int i = countLeft, j = countRight; i < j;)
	{
		if (array[i] > array[j])
		{
			int const helpValue = array[i];
			array[i] = array[j];
			array[j] = helpValue;
		}
		if (array[i] < value)
		{
			i++;
		}
		else
		{
			j--;
		}
		if (i == j)
		{
			if (i - countLeft + 1 >= 3)
			{
				qsort(countLeft, i, array);
			}
			if (countRight - j + 1 >= 3)
			{
				qsort(j + 1, countRight, array);
			}
		}
	}
}