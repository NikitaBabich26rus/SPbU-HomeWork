#include <stdio.h>
#include "Prim.h"
#include <locale.h>

void createEdge(int graph[][size], int firstVertex, int secondVertex, int length)
{
	graph[firstVertex - 1][secondVertex - 1] = length;
	graph[secondVertex - 1][firstVertex - 1] = length;
}

void inputData(FILE* file, int *sizeOfGraph, int *count, int graph[][size])
{
	fscanf(file, "%d", sizeOfGraph);
	fscanf(file, "%d", count);
	for (int i = 0; i < (*count); i++)
	{
		int k = 0;
		fscanf(file, "%d", &k);
		int t = 0;
		fscanf(file, "%d", &t);
		int length = 0;
		fscanf(file, "%d", &length);
		createEdge(graph, k, t, length);
	}
}

bool test()
{
	int testGraph[size][size]{};
	int testParent[size]{};
	int answerArray[size]{ 0, 0, 4, 0, 1, 3, 4 };
	int sizeOfGraph = 0;
	int count = 0;
	FILE* file = fopen("Test.txt", "r");
	inputData(file, &sizeOfGraph, &count, testGraph);
	prim(testGraph, sizeOfGraph, testParent, 0);
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (testParent[i] != answerArray[i])
		{
			return false;
		}
	}
	fclose(file);
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
	int count = 0;

	inputData(file, &sizeOfGraph, &count, graph);

	fclose(file);
	prim(graph, sizeOfGraph, parent, startVertex);
	outputResult(parent, sizeOfGraph);
	return 0;
}
