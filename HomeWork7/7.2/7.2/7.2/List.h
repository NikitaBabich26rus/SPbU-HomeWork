#pragma once

struct ListElement
{
	int value;
	ListElement* next;
};

struct List
{
	ListElement* head = nullptr;
	ListElement* tail = nullptr;
};

List* createList();

bool empty(List* head);

void push(List* list, int value);

void deleteElement(List* list, ListElement* value);

void outputList(List* list);

void outputList(List* list);