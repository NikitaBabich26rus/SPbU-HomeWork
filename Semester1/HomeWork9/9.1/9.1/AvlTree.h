#pragma once

// Длина слова
const int sizeOfWord = 30;

// Двоичное дерево
struct Set;

// Создать двоичное дерево
Set* createSet();

// Удалить двоичное дерево
void deleteSet(Set* set);

// Проверка элемента на принадлежность двоичному дереву
bool isContained(int key, Set* set);

// Добавить элемент в двоичное дерево
void addElement(int key, Set* set, char word[]);

// Удалить элемент из двоичного дерева
bool deleteElement(int key, Set* set);

// Получить слово по ключу из двоичного дерева
char* getWord(int key, Set* set);
