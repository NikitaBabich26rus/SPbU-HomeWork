#include "Dka.h"

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
				state = 2;
				count++;
				break;
			}
			else if (currentSymbol == '+' || currentSymbol == '-')
			{
				state = 1;
				count++;
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
				state = 2;
				count++;
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
				count++;
				break;
			}
			else if (currentSymbol == 'E')
			{
				state = 5;
				count++;
				break;
			}
			else if (currentSymbol == '\0')
			{
				return true;
			}
			else if (currentSymbol == '.' || currentSymbol == ',')
			{
				count++;
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
				count++;
				state = 4;
				break;
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
				count++;
				break;
			}
			else if (currentSymbol == 'E')
			{
				state = 5;
				count++;
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
		case 5:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 7;
				count++;
				break;
			}
			if (currentSymbol == '+' || currentSymbol == '-')
			{
				state = 6;
				count++;
				break;
			}
			else
			{
				return false;
			}
		}
		case 6:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				state = 7;
				count++;
				break;
			}
			else
			{
				return false;
			}
		}
		case 7:
		{
			if (currentSymbol >= '0' && currentSymbol <= '9')
			{
				count++;
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
		}
	}
}