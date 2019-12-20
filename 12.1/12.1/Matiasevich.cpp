#include "Matiasevich.h"
#include <stdio.h>
#include <string.h>

int* createPi(char stringForSearching[])
{
	int size = strlen(stringForSearching) - 1;
	int* pi = new int[size + 1] {};
	int i = 1;
	int j = 0;
	while (i < size)
	{
		if (stringForSearching[i] != stringForSearching[j])
		{
			if (j == 0)
			{
				pi[i] = 0;
				i++;
			}
			else
			{
				j = pi[j - 1];
			}
		}
		else
		{
			pi[i] = j + 1;
			i++;
			j++;
		}
	}
	return pi;
}

int matiasevich(char string[], char stringForSearching[])
{
	int* pi = createPi(stringForSearching);
	int stringSize = strlen(string) - 1;
	int stringForSearchSize = strlen(stringForSearching) - 1;
	int l = 0;
	int k = 0;
	while (k <= stringSize)
	{
		if (string[k] == stringForSearching[l])
		{
			if (l == stringForSearchSize)
			{
				delete[] pi;
				return k - l;
			}
			k++;
			l++;
		}
		else
		{
			if (l == 0)
			{
				k++;
			}
			else
			{
				l = pi[l - 1];
			}
		}
	}
	delete[] pi;
	return -1;
}