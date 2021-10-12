#pragma once

// Элемент списка
struct ListElement;

// Список 
struct List;

// Создать список
List* createList();

// Проверка списка на пустоту
bool empty(List* head);

// Добавить элемент списка
void push(List* list, int value);

// Удалить элемент списка
void deleteElement(List* list, int value);

// Вывести список
void outputList(List* list);

// Проверить список на отсортированность
bool checkSort(List* list);

// Проверка списка на наличие в нем данного элемента
bool contains(List* list, int value);

// Удалить список
void deleteList(List* list);
