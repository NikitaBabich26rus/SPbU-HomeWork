#include <stdio.h>

const int sizeOfArray = 50;

void dfs(int graph[][sizeOfArray], bool* used, int currentVertex, int amountOfVertexes, int amountOfEdges)
{
	used[currentVertex] = true;
	for (int i = 0; i < amountOfEdges; i++)
	{
		if (graph[currentVertex][i] == 1)
		{
			for (int j = 0; j < amountOfVertexes; j++)
			{
				if (graph[j][i] == -1 && !used[j])
				{
					dfs(graph, used, j, amountOfVertexes, amountOfEdges);
				}
			}
		}
	}
}

void algorithm(int graph[][sizeOfArray], int amountOfVertexes, int amountOfEdges, bool* answerArray)
{
	for (int i = 0; i < amountOfVertexes; i++)
	{
		bool* used = new bool[amountOfVertexes] {};
		dfs(graph, used, i, amountOfVertexes, amountOfEdges);
		for (int j = 0; j < amountOfVertexes; j++)
		{
			if (!used[j])
			{
				answerArray[j] = false;
			}
		}
		delete[] used;
	}
}

int main()
{
	int amountOfVertexes = 0;
	printf("Input amount of vertex < 50 : ");
	scanf("%d", &amountOfVertexes);
	int amountOfEdges = 0;
	printf("Input amount of edges < 50 : ");
	scanf("%d", &amountOfEdges);
	int graph[sizeOfArray][sizeOfArray]{};
	for (int i = 0; i < amountOfEdges; i++)
	{
		int VertexTo = 0;
		int VertexFrom = 0;
		printf("Input the vertex from which the edge goes : ");
		scanf("%d", &VertexFrom);
		printf("Input the vertex where the edge goes : ");
		scanf("%d", &VertexTo);
		VertexFrom--;
		VertexTo--;
		graph[VertexFrom][i] = 1;
		graph[VertexTo][i] = -1;
	}
	bool* answerArray = new bool[amountOfVertexes] {};
	for (int i = 0; i < amountOfVertexes; i++)
	{
		answerArray[i] = true;
	}
	algorithm(graph, amountOfVertexes, amountOfEdges, answerArray);
	printf("Answer : ");
	for (int i = 0; i < amountOfVertexes; i++)
	{
		if (answerArray[i])
		{
			printf("%d ", i + 1);
		}
	}
	delete[] answerArray;
	return 0;
}

