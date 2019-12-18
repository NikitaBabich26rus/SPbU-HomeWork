
#pragma once

const int sizeOfWord = 20;

// Элемент списка
struct ListElement;

// Список 
struct List;

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

// Получить размер списка
int getSizeOfList(List* list);

// Получить первый элемент списка
ListElement* getListHead(List* list);

// Получить слово, принадлежащее элементу списка
char* getWordOfListElement(ListElement* element);

// Получить количество элемента списка
int getAmountOfListElement(ListElement* element);

// Получить указатель на следущий элемент списка
ListElement* getNextListElement(ListElement* element);

// Проверка элемента на принадлежность списку
// Если принадлежит, то добавить такой же элемент
bool containsAndAddInList(List* list, char word[]);