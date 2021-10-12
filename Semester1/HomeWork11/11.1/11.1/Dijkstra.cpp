#include "List.h"
#include "Dijkstra.h"

void dijkstra(int graph[][size], int distance[][size], bool used[], List* countries[], int sizeOfGraph, int currentVertex)
{
	int minDistance = maxDistance;
	int minDistanceNumber = -1;
	for (int j = 0; j < sizeOfGraph; j++)
	{
		if (minDistance > distance[currentVertex][j] && !used[j])
		{
			minDistance = distance[currentVertex][j];
			minDistanceNumber = j;
		}
	}
	if (minDistanceNumber == -1)
	{
		return;
	}
	used[minDistanceNumber] = true;
	push(countries[currentVertex], minDistanceNumber);
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (distance[currentVertex][i] > distance[currentVertex][minDistanceNumber] + graph[minDistanceNumber][i] && graph[minDistanceNumber][i] != 0)
		{
			distance[currentVertex][i] = distance[currentVertex][minDistanceNumber] + graph[minDistanceNumber][i];
		}
	}
}

void algorithm(int graph[][size], int capitals[], int amountOfCapitals, int sizeOfGraph, List* countries[])
{
	int distance[size][size]{};
	bool used[size]{};
	for (int i = 0; i < amountOfCapitals; i++)
	{
		countries[capitals[i]] = nullptr;
		countries[capitals[i]] = createList();
		for (int j = 0; j < sizeOfGraph; j++)
		{
			distance[capitals[i]][j] = maxDistance;
			if (capitals[i] == j)
			{
				distance[capitals[i]][j] = 0;
			}
		}
	}
	for (int j = 0; j < sizeOfGraph; j++)
	{
		for (int i = 0; i < amountOfCapitals; i++)
		{
			dijkstra(graph, distance, used, countries, sizeOfGraph, capitals[i]);
		}
	}
}
