#pragma once

// Список
struct List;

// Соединение двух неотсортированных списков в один
List* merge(List* leftList, List* rightList);

// Функция сортировки слиянием
List* mergeSort(List* list);
