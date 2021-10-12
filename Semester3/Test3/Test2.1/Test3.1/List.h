#pragma once

// Элемент списка
struct ListElement;

//  Список
struct List;

// Создать список
List* createList();

// Проверка списка на пустоту
bool empty(List* head);

// Добавить элемент в список
void push(List* list, int value);

// Удалить элемент из списка
void deleteElement(List* list, int value);

// Вывести список
void outputList(List* list);

// Проверка списка на отсоритрованность
bool checkSort(List* list);

// Проверка элемента на принадлежность списку
bool contains(List* list, int value);

// Удалить список
void deleteList(List* list);

int algotithm(List* list, int *lastPosition);

void pustToNewListFromOldList(List* list, List* newList, int position, int* size);