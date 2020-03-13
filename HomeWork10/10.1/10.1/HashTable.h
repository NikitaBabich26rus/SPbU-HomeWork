#pragma once

// Хеш-таблица
struct HashTable;

// Список
struct List;

// Создать хеш-таблицу
HashTable* createHashTable(int hashSize);

// Добавить элемент в хеш-таблицу
HashTable* addToTable(HashTable* table, char word[], int amount);

// Проверить хеш-таблицу на наличие элемента
bool containsInTable(HashTable* table, char word[]);

// Удалить хеш-таблицу
void deleteTable(HashTable* table);

// Вывести хеш-таблицу
void outputTable(HashTable* table);

// Получить список, принадлежащий хеш-таблице
List* getListFromTable(HashTable* table, char word[]);

// Изменить размер хеш-таблицы
HashTable* resizeOfTable(HashTable* oldTable);

// Вывести результат программы
void outputStatistics(HashTable* table);
