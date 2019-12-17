
#include <stdio.h>
#include "List.h"
#include <locale.h>

int main()
{
	setlocale(LC_ALL, "Russian");
	List* list = createList();
	while (true)
	{
		int value = 0;
		printf("Введите значение элемента : ");
		scanf("%d", &value);
		if (value == 0)
		{
			outputList(list);
			deleteList(list);
			return 0;
		}
		push(list, value);
	}
	return 0;
}

