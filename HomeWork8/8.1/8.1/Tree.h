#pragma once

const int sizeOfWord = 50;

struct Tree;

struct TreeElement;

Tree* create();

bool empty(Tree* tree);

void push(Tree* tree, int key, char word[]);

TreeElement* checkElementInTree(Tree* tree, int key);

bool checkKeyInTree(Tree* tree, int key);

char* checkWordInTree(Tree* tree, int key);

TreeElement* checkElementInTreeAndParent(Tree* tree, int key, TreeElement** parent);

TreeElement* findLeftMax(TreeElement* element, TreeElement** parent);

void setChild(TreeElement* parent, TreeElement* oldChild, TreeElement* newChild);

void deleteElement(Tree* tree, int key);

void deleteTree(Tree* tree);