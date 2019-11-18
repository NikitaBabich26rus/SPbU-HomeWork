#pragma once

// Элементы циклического списка списка
struct ListElement;

// Циклический список
struct List;

// Создать циклический список
List* createList();

// Проверка циклического списка на наличие элементов
bool empty(List* head);

// Добавить элемент в циклический список
void push(List* list, int value);

// Удалить элемент из циклического списка
void deleteElement(List* list, ListElement* value);

// Вывод циклического списка
void outputList(List* list);

// Взять элемент стоящий в конце циклического списка
ListElement* takeTail(List* list);

// Возвращает следующий эдемент
ListElement* takeNextElement(ListElement* element);

// Возвращает значение элемента
int takeValue(ListElement* element);