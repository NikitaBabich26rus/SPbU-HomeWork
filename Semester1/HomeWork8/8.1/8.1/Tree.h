#pragma once

// ����� ����� � �������
const int sizeOfWord = 50;

// ������ 
struct Tree;

// ������� ������
Tree* create();

// �������� ������ �� �������
bool empty(Tree* tree);

// ���������� ������ �������� � ������
void push(Tree* tree, int key, char word[]);

// �������� ������ �� ������� �����
bool isKeyInTree(Tree* tree, int key);

// �������� ������ �� ������� �����
char* getWordInTree(Tree* tree, int key);

// ����� ����������� ��������� �������� �������� � ������
void checkElementForDelete(Tree* tree, int key);

// �������� ������
void deleteTree(Tree* tree);