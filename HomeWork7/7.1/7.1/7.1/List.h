#pragma once


struct ListElement
{
	int value;
	ListElement* next;
};

struct List
{
	ListElement* head = nullptr;
};

List* createList();

bool empty(List* head);

void push(List* list, int value);

void deleteElement(List* list, int value);

void outputList(List* list);

bool checkSort(List* list);

bool checkElement(List* list, int value);

void outputList(List* list);

void deleteList(List* list);