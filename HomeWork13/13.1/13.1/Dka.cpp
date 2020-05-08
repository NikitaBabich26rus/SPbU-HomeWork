#include "Dka.h"
#include <stdio.h>

bool analyzer(char string[])
{
	int count = 0;
	int state = 0;
	while (true)
	{
		char currentSymbol = string[count];
		switch (state)
		{
		case 0:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 1;
				break;
			}
			else
			{
				return false;
			}
		}
		case 1:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				break;
			}
			else if (currentSymbol == 'E')
			{
				state = 4;
				break;
			}
			else if (currentSymbol == '\0')
			{
				return true;
			}
			else if (currentSymbol == '.')
			{
				state = 2;
				break;
			}
			else
			{
				return false;
			}
		}
		case 2:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 3;
				break;
			}
			else
			{
				return false;
			}
		}
		case 3:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				break;
			}
			else if (currentSymbol == 'E')
			{
				state = 4;
				break;
			}
			else if (currentSymbol == '\0')
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		case 4:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 6;
				break;
			}
			if (currentSymbol == '+' || currentSymbol == '-')
			{
				state = 5;
				break;
			}
			return false;
		}
		case 5:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 6;
				break;
			}
			return false;
		}
		case 6:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				break;
			}
			return currentSymbol == '\0';
		}
		}
		count++;
	}
}