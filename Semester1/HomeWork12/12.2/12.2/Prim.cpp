#include "Prim.h"
#include <stdio.h>


void counting(int graph[][size], bool used[], int sizeOfGraph, int parent[])
{
	int minDistance = maxDistance;
	int minDistanceNumberTo = -1;
	int minDistanceNumberFrom = -1;
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (!used[i])
		{
			continue;
		}
		for (int j = 0; j < sizeOfGraph; j++)
		{
			if (graph[i][j] < minDistance && graph[i][j] != 0 && !used[j])
			{
				minDistance = graph[i][j];
				minDistanceNumberTo = j;
				minDistanceNumberFrom = i;
			}
		}
	}
	if (minDistanceNumberTo == -1)
	{
		return;
	}
	used[minDistanceNumberTo] = true;
	parent[minDistanceNumberTo] = minDistanceNumberFrom;
}

void prim(int graph[][size], int sizeOfGraph, int parent[], int startVertex)
{
	bool used[size]{};
	for (int i = 0; i < sizeOfGraph; i++)
	{
		used[i] = false;
	}
	used[startVertex] = true;
	for (int i = 0; i < sizeOfGraph; i++)
	{
		counting(graph, used, sizeOfGraph, parent);
	}
}

void outputResult(int array[], int sizeOfGraph)
{
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (array[i] != i)
		{
			printf("Родитель : ");
			printf("%d, ", array[i] + 1);
			printf("Ребенок : ");
			printf("%d\n", i + 1);
		}
	}
}