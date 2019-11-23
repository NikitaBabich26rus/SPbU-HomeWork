#pragma once

const int sizeOfString = 50;

struct List;

struct ListElement;

List* createList();

void push(List* list, char mainString[], char sideString[]);

void output(List* list);

int sizeOfList(List* list);

List* createNewLeftlist(List* list, int mid);

List* createNewRightList(List* list, int mid);

int takeListSize(List* list);

bool empty(List* list);

void transferLastValues(List* oldList, List* newList);

void pushToNewList(List* list, List* leftList, List* rightList);