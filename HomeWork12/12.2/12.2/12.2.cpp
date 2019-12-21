#include <stdio.h>
#include "Prim.h"
#include <locale.h>

void createEdge(int graph[][size], int firstVertex, int secondVertex, int length)
{
	graph[firstVertex - 1][secondVertex - 1] = length;
	graph[secondVertex - 1][firstVertex - 1] = length;
}

bool test()
{
	int TestGraph[size][size]{};
	int TestParent[size]{};
	int answerArray[size]{ 0, 0, 4, 0, 1, 3, 4 };

	FILE* file = fopen("Input.txt", "r");
	int sizeOfGraph = 0;
	fscanf(file, "%d", &sizeOfGraph);
	int count = 0;
	fscanf(file, "%d", &count);

	for (int i = 0; i < count; i++)
	{
		int k = 0;
		fscanf(file, "%d", &k);
		int t = 0;
		fscanf(file, "%d", &t);
		int length = 0;
		fscanf(file, "%d", &length);
		createEdge(TestGraph, k, t, length);
	}
	prim(TestGraph, sizeOfGraph, TestParent, 0);
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (TestParent[i] != answerArray[i])
		{
			return false;
		}
	}
	return true;
}

int main()
{
	if (!test())
	{
		return -1;
	}
	setlocale(LC_ALL, "Russian");

	int startVertex = 0;
	printf("Введите стартовую вершину : ");
	scanf("%d", &startVertex);
	startVertex--;

	int graph[size][size]{};
	int parent[size]{};

	FILE* file = fopen("Input.txt", "r");
	int sizeOfGraph = 0;
	fscanf(file, "%d", &sizeOfGraph);
	int count = 0;
	fscanf(file, "%d", &count);
	for (int i = 0; i < count; i++)
	{
		int k = 0;
		fscanf(file, "%d", &k);
		int t = 0;
		fscanf(file, "%d", &t);
		int length = 0;
		fscanf(file, "%d", &length);
		createEdge(graph, k, t, length);
	}

	prim(graph, sizeOfGraph, parent, startVertex);
	outputResult(parent, sizeOfGraph);
	return 0;
}
