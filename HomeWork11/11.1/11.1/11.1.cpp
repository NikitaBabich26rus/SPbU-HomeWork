
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

	FILE* file = fopen("11.1Test.txt", "r");
	int n = 0;
	fscanf(file, "%d", &n);
	int m = 0;
	fscanf(file, "%d", &m);
	for (int i = 0; i < m; i++)
	{
		int k = 0;
		fscanf(file, "%d", &k);
		int t = 0;
		fscanf(file, "%d", &t);
		int length = 0;
		fscanf(file, "%d", &length);
		createEdge(graphTest, k, t, length);
	}
	int k = 0;
	fscanf(file, "%d", &k);
	if (k == 0)
	{
		return true;
	}
	int* capitals = new int[k] {};
	List* countries[size];
	for (int i = 0; i < k; i++)
	{
		fscanf(file, "%d", &capitals[i]);
		capitals[i]--;
	}
	algorithm(graphTest, capitals, k, n, countries);
	if (!checkCountry(countries[1], country2, 2))
	{
		test1 = false;
	}
	if (!checkCountry(countries[2], country3, 1))
	{
		test2 = false;
	}
	if (!checkCountry(countries[3], country4, 2))
	{
		test3 = false;
	}
	deleteList(countries[1]);
	deleteList(countries[2]);
	deleteList(countries[3]);
	delete[] capitals;
	return test1 && test2 && test3;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Russian");
	int graph[size][size]{};
	FILE* file = fopen("11.1Input.txt", "r");
	int n = 0;
	fscanf(file, "%d", &n);
	int m = 0;
	fscanf(file, "%d", &m);
	for (int i = 0; i < m; i++)
	{
		int k = 0;
		fscanf(file, "%d", &k);
		int t = 0;
		fscanf(file, "%d", &t);
		int length = 0;
		fscanf(file, "%d", &length);
		createEdge(graph, k, t, length);
	}
	int k = 0;
	fscanf(file, "%d", &k);
	if (k == 0)
	{
		return true;
	}
	int* capitals = new int[k] {};
	List* countries[size];
	for (int i = 0; i < k; i++)
	{
		fscanf(file, "%d", &capitals[i]);
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
	return 0;
}