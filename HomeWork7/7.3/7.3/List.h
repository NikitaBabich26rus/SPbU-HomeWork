#pragma once

const int sizeOfString = 50;

struct List;

struct ListElement;

List* createList();

void push(List* list, char mainString[], char sideString[]);

void output(List* list);

void createNewLeftList(List* list, List* leftList, int size);

void createNewRightList(List* list, List* rightList, int size);

int takeListSize(List* list);

bool empty(List* list);

void transferLastValues(List* oldList, List* newList);

void pushToNewList(List* list, List* leftList, List* rightList);

bool checkSort(List* list);