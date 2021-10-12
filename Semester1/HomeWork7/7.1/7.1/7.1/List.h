#pragma once

// Элементы списка
struct ListElement;

// Список - структура данных, позволяющая хранить элементы 
struct List;

// Создать список
List* createList();

// Проверка списка на наличие элементов
bool empty(List* head);

// Добавить элемент
void push(List* list, int value);

// Удалить элемент
void deleteElement(List* list, int value);

// Вывести лист
void outputList(List* list);

// Проверить список на сортированность
bool checkSort(List* list);

// Проверить список на налчие элемента
bool contains(List* list, int value);

// Удалить список
void deleteList(List* list);