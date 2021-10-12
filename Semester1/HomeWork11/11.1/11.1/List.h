#pragma once

// Элемент списка
struct ListElement;

// Список 
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

// Проверить элемент на принадлежность списку
bool contains(List* list, int value);

// Удалить список
void deleteList(List* list);

// Проверка страны на содержание городов
bool checkCountry(List* list, int country[], int size);