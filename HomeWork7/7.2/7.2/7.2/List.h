#pragma once

// Элементы циклического списка списка
struct ListElement;

// Циклический список
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

