#pragma once

// Максимальное расстояние
const int maxDistance = 1000000000;

// Длина и высота массива
const int size = 100;

// Алгоритм прима
void prim(int graph[][size], int sizeOfGraph, int parent[], int startVertex);

// Вывести результат программы
void outputResult(int array[], int sizeOfGraph);