#pragma once

// Размер номера телефона и имени
const int sizeOfString = 50;

// Список
struct List;

// Элемент списка
struct ListElement;

// Создать список
List* createList();

// Добавить элемент в список
void push(List* list, char mainString[], char sideString[]);

// Вывести список
void output(List* list);

// Создать новый список из левой части старого списка
void createNewLeftList(List* list, List* leftList, int size);

// Создать новый список из правой части старого списка
void createNewRightList(List* list, List* rightList, int size);

// Возвращает размер списка
int getListSize(List* list);

// Проверка списка на пустоту 
bool empty(List* list);

// Передать последние значение из левого или правого списка в новый(во время слияния)
void transferLastValues(List* oldList, List* newList);

// Добавить элемент в новый список(во время слияния) 
void pushToNewList(List* list, List* leftList, List* rightList);

// Проверка на списка на отсоритрованность по неубыванию
bool checkSort(List* list);

// Удаление списка
void deleteList(List* list);