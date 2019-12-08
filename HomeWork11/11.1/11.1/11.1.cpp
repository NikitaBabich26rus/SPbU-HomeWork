
#include <stdio.h>
#include "List.h"
#include <locale.h>
#include "Dijkstra.h"

void createEdge(int graph[][size], int firstVertex, int secondVertex, int length)
{
	graph[firstVertex - 1][secondVertex - 1] = length;
	graph[secondVertex - 1][firstVertex - 1] = length;
}

bool test()
{
	bool test1 = true;
	bool test2 = true;
	bool test3 = true;
	int country2[2]{ 1, 0 };
	int country3[1]{ 2 };
	int country4[2]{ 3, 4 };
	int graphTest[size][size]{};
	int capitals[3]{ 1, 2, 3 }; // Столицы : 2, 3, 4.

	createEdge(graphTest, 1, 2, 12);
	createEdge(graphTest, 2, 3, 27);
	createEdge(graphTest, 2, 5, 48);
	createEdge(graphTest, 3, 4, 37);
	createEdge(graphTest, 4, 5, 13);

	List* countries[size];
	algorithm(graphTest, capitals, 3, 5, countries);
	if (!checkCountry(countries[1], country2, 2))
	{
		deleteList(countries[1]);
		test1 = false;
	}
	if (!checkCountry(countries[2], country3, 1))
	{
		deleteList(countries[2]);
		test2 = false;
	}
	if (!checkCountry(countries[3], country4, 2))
	{
		deleteList(countries[3]);
		test3 = false;
	}
	return test1 && test2 && test3;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Russian");
	printf("Введите число городов : ");
	int n = 0;
	scanf("%d", &n);
	printf("Введите число дорог : ");
	int m = 0;
	scanf("%d", &m);
	int graph[size][size]{};
	for (int i = 0; i < m; i++)
	{
		printf("Введите номер города : ");
		int k = 0;
		scanf("%d", &k);
		printf("Введите номер города : ");
		int t = 0;
		scanf("%d", &t);
		printf("Введите длину дороги между этими городами : ");
		int length = 0;
		scanf("%d", &length);
		createEdge(graph, k, t, length);
	}
	int k = 0;
	printf("Введите количество столиц : ");
	scanf("%d", &k);
	if (!k)
	{
		return 0;
	}
	int* capitals = new int[k]{};
	List* countries[size];
	printf("Введите столицы : ");
	for (int i = 0; i < k; i++)
	{
		scanf("%d", &capitals[i]);
		capitals[i]--;
	}
	algorithm(graph, capitals, k, n, countries);
	for (int i = 0; i < k; i++)
	{
		printf("Государство номер ");
		printf("%d : ", capitals[i] + 1);
		outputList(countries[capitals[i]]);
		deleteList(countries[capitals[i]]);
		printf("\n");
	}
	delete[] capitals;
}