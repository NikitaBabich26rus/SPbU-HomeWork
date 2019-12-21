#pragma once

// Дерево разбора арифметического выражения
struct Tree;

// Создать дерево разбора арифметического выражения
Tree* createTree();

// Построить дерево разбора арифметического выражения
void buildTree(Tree* tree, char string[]);

// Вывести дерево разбора арифметического выражения
void outputTree(Tree* tree);

// Посчитать результат в дереве разбора арифметического выражения
void toCountResult(Tree* tree);

// Получить значение из корня дерева
int getValueOfRoot(Tree* tree);

// Удалить дерево разбора арифметического выражения
void deleteTree(Tree* tree);