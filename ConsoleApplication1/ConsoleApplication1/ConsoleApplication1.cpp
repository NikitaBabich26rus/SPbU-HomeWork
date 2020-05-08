
#include <stdio.h>

void outputComments()
{
	FILE* file = fopen("Test.txt", "r");
	bool help = false;
	while (!feof(file))
	{
		const char value = fgetc(file);
		if (value == ';' || help)
		{
			if (!help)
			{
				help = true;
			}
			if (value == '\n')
			{
				help = false;
				printf("\n");
			}
			if (help)
			{
				printf("%c", value);
			}
		}
	}
}

int main()
{
	outputComments();
	return 0;
}

