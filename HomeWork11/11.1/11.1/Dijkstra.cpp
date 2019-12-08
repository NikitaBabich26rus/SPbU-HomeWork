#include "List.h"
#include "Dijkstra.h"


int dijkstra(int graph[][size], int distance[][size], bool used[], List* countries[], int sizeOfGraph, int currentVertex, int counter)
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
		return counter;
	}
	counter--;
	used[minDistanceNumber] = true;
	push(countries[currentVertex], minDistanceNumber);
	for (int i = 0; i < sizeOfGraph; i++)
	{
		if (distance[currentVertex][i] > distance[currentVertex][minDistanceNumber] + graph[minDistanceNumber][i] && graph[minDistanceNumber][i] != 0)
		{
			distance[currentVertex][i] = distance[currentVertex][minDistanceNumber] + graph[minDistanceNumber][i];
		}
	}
	return counter;
}



void algorithm(int graph[][size], int capitals[], int amountOfCapitals, int sizeOfGraph, List* countries[])
{
	int counter = sizeOfGraph;
	int distance[size][size]{};
	bool used[10]{};
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
	while (counter)
	{
		for (int i = 0; i < amountOfCapitals; i++)
		{
			counter = dijkstra(graph, distance, used, countries, sizeOfGraph, capitals[i], counter);
		}
	}
}
