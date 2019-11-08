#pragma once

// Элементы списка
struct ListElement;

// Список
struct List;

// Создать список
List* createList();

// Проверка списка на наличие элементов
bool empty(List* head);

// Добавить элемент в список
void push(List* list, int value);

// Удалить элемент из списка
void deleteElement(List* list, ListElement* value);

// Вывод списка
void outputList(List* list);

// Реализация алгоритма
int algorithm(int size, int count);