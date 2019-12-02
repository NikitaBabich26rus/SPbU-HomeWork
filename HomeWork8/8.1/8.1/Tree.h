#pragma once

// Длина слова в словаре
const int sizeOfWord = 50;

// Дерево 
struct Tree;

// Элемент дерева
struct TreeElement;

// Создать дерево
Tree* create();

// Проверка дерева на пустоту
bool empty(Tree* tree);

// Добавление нового элемента в дерево
void push(Tree* tree, int key, char word[]);

// Проверка дерева на наличие ключа
bool checkKeyInTree(Tree* tree, int key);

// Проверка дерева на наличие слова
char* checkWordInTree(Tree* tree, int key);

// Выбор правильного алгоритма удаление элемента в дереве
void checkElementForDelete(Tree* tree, int key);

// Удаление дерева
void deleteTree(Tree* tree);