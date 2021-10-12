
#pragma once

const int sizeOfWord = 20;

// ������� ������
struct ListElement;

// ������ 
struct List;

// ������� ������
List* createList();

// �������� ������ �� �������
bool empty(List* head);

// �������� ������� � ������
void addToList(List* list, char word[], int amount);

// ������� ������
void outputList(List* list);

// �������� �������� �� �������������� ������
bool containsInList(List* list, char word[]);

// ������� ������
void deleteList(List* list);

// �������� ������ ������
int getSizeOfList(List* list);

// �������� ������ ������� ������
ListElement* getListHead(List* list);

// �������� �����, ������������� �������� ������
char* getWordOfListElement(ListElement* element);

// �������� ���������� �������� ������
int getAmountOfListElement(ListElement* element);

// �������� ��������� �� �������� ������� ������
ListElement* getNextListElement(ListElement* element);

// �������� �������� �� �������������� ������
// ���� �����������, �� �������� ����� �� �������
bool containsAndAddInList(List* list, char word[]);