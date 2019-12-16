#include "Matiasevich.h"
#include <stdio.h>

int getSizeOfString(char string[])
{
	for (int i = 0; true; i++)
	{
		if (string[i] == '\0')
		{
			return i - 1;
		}
	}
}

int* createPi(char obraz[])
{
	int size = getSizeOfString(obraz);
	int* pi = new int[size + 1] {};
	int i = 1;
	int j = 0;
	while (i < size)
	{
		if (obraz[i] != obraz[j])
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

int Matiasevich(char string[], char obraz[])
{
	int* pi = createPi(obraz);
	int stringSize = getSizeOfString(string);
	int obrazSize = getSizeOfString(obraz);
	int l = 0;
	int k = 0;
	while (k <= stringSize)
	{
		if (string[k] == obraz[l])
		{
			if (l == obrazSize)
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