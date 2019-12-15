
#pragma once

const int sizeOfWord = 20;

// Элемент списка
struct ListElement;

// Список 
struct List;

// Хеш-таблица
struct HashTable;

// Создать список
List* createList();

// Проверка списка на пустоту
bool empty(List* head);

// Добавить элемент в список
void addToList(List* list, char word[], int amount);

// Вывести список
void outputList(List* list);

// Проверка элемента на принадлежность списку
bool containsInList(List* list, char word[]);

// Удалить список
void deleteList(List* list);

// Перенести элементы из списка старой хеш-таблицы в новую хеш-таблицу
void pushToNewTableFromOldList(List* oldList, HashTable* newTable);

// Получить размер списка
int getSizeOfList(List* list);

// Проверка элемента на принадлежность списку
// Если принадлежит, то добавить такой же элемент
bool containsAndAddInList(List* list, char word[]);