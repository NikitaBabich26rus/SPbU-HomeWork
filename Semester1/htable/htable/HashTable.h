#pragma once

// ���-�������
struct HashTable;

// ������
struct List;

// ������� ���-�������
HashTable* createHashTable(int hashSize);

// �������� ������� � ���-�������
HashTable* addToTable(HashTable* table, char word[], int amount);

// ��������� ���-������� �� ������� ��������
bool containsInTable(HashTable* table, char word[]);

// ������� ���-�������
void deleteTable(HashTable* table);

// ������� ���-�������
void outputTable(HashTable* table);

// �������� ������, ������������� ���-�������
List* getListFromTable(HashTable* table, char word[]);

// �������� ������ ���-�������
HashTable* resizeOfTable(HashTable* oldTable);

// ������� ��������� ���������
void outputResultOfProgram(HashTable* table);