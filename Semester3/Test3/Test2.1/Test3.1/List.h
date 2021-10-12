#pragma once

// ������� ������
struct ListElement;

//  ������
struct List;

// ������� ������
List* createList();

// �������� ������ �� �������
bool empty(List* head);

// �������� ������� � ������
void push(List* list, int value);

// ������� ������� �� ������
void deleteElement(List* list, int value);

// ������� ������
void outputList(List* list);

// �������� ������ �� �����������������
bool checkSort(List* list);

// �������� �������� �� �������������� ������
bool contains(List* list, int value);

// ������� ������
void deleteList(List* list);

int algotithm(List* list, int *lastPosition);

void pustToNewListFromOldList(List* list, List* newList, int position, int* size);