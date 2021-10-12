#pragma once

// ������� ������
struct ListElement;

// ������ 
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

// ��������� ������� �� �������������� ������
bool contains(List* list, int value);

// ������� ������
void deleteList(List* list);

// �������� ������ �� ���������� �������
bool checkCountry(List* list, int country[], int size);