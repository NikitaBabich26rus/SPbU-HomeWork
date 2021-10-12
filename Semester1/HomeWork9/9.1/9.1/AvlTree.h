#pragma once

// ����� �����
const int sizeOfWord = 30;

// �������� ������
struct Set;

// ������� �������� ������
Set* createSet();

// ������� �������� ������
void deleteSet(Set* set);

// �������� �������� �� �������������� ��������� ������
bool isContained(int key, Set* set);

// �������� ������� � �������� ������
void addElement(int key, Set* set, char word[]);

// ������� ������� �� ��������� ������
bool deleteElement(int key, Set* set);

// �������� ����� �� ����� �� ��������� ������
char* getWord(int key, Set* set);
