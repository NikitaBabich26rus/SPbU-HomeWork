#pragma once

const int maxDistance = 1000000;
const int size = 100;

// Алгоритм выбирающий подходящую вершину для запуска алгоритма Дейкстры
void algorithm(int graph[][size], int capitals[], int amountOfCapitals, int sizeOfGraph, List* countries[]);
