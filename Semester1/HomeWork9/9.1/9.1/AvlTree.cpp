#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "AvlTree.h"


struct SetElement
{
	int key = 0;
	int height = 0;
	char word[sizeOfWord];
	SetElement* leftChild = nullptr;
	SetElement* rightChild = nullptr;
};

struct Set
{
	SetElement* root = nullptr;
};

int getHeight(SetElement* element)
{
	if (element != nullptr)
	{
		return element->height;
	}
	return -1;
}

int getBalanceFactor(SetElement* element)
{
	return getHeight(element->rightChild) - getHeight(element->leftChild);
}

int max(int element1, int element2)
{
	if (element1 > element2)
	{
		return element1;
	}
	return element2;
}

void updateHeight(SetElement* element)
{
	if (element == nullptr)
	{
		return;
	}
	int heightLeftChild = getHeight(element->leftChild);
	int heightRightChild = getHeight(element->rightChild);
	element->height = max(heightLeftChild, heightRightChild) + 1;
}

Set* createSet()
{
	return new Set;
}

SetElement* getSetElement(int value, Set* set)
{
	if (set->root == nullptr)
	{
		return nullptr;
	}
	SetElement* currentElement = set->root;
	while (currentElement != nullptr)
	{
		if (currentElement->key == value)
		{
			return currentElement;
		}
		else if (currentElement->key > value)
		{
			currentElement = currentElement->leftChild;
		}
		else
		{
			currentElement = currentElement->rightChild;
		}
	}
	return nullptr;
}

char* getWord(int key, Set* set)
{
	SetElement* element = getSetElement(key, set);
	if (element == nullptr)
	{
		return nullptr;
	}
	return element->word;
}

bool isContained(int key, Set* set)
{
	return getSetElement(key, set) != nullptr;
}

SetElement* rotateRight(SetElement* element)
{
	if (element == nullptr)
	{
		return nullptr;
	}
	SetElement* pivotElement = element->leftChild;
	element->leftChild = pivotElement->rightChild;
	pivotElement->rightChild = element;
	updateHeight(element);
	updateHeight(pivotElement);
	return pivotElement;
}

SetElement* rotateLeft(SetElement* element)
{
	if (element == nullptr)
	{
		return nullptr;
	}
	SetElement* pivotElement = element->rightChild;
	element->rightChild = pivotElement->leftChild;
	pivotElement->leftChild = element;
	updateHeight(element);
	updateHeight(pivotElement);
	return pivotElement;
}

SetElement* balance(SetElement* element)
{
	updateHeight(element);
	if (getBalanceFactor(element) == 2)
	{
		if (getBalanceFactor(element->rightChild) < 0)
		{
			element->rightChild = rotateRight(element->rightChild);
		}
		return rotateLeft(element);
	}
	if (getBalanceFactor(element) == -2)
	{
		if (getBalanceFactor(element->leftChild) > 0)
		{
			element->leftChild = rotateLeft(element->leftChild);
		}
		return rotateRight(element);
	}
	return element;
}

SetElement* addElementInSubtree(int key, SetElement* element, char word[])
{
	if (element == nullptr)
	{
		SetElement* newElement = new SetElement;
		strcpy(newElement->word, word);
		newElement->key = key;
		return newElement;
	}
	if (key < element->key)
	{
		element->leftChild = addElementInSubtree(key, element->leftChild, word);
	}
	else if (key > element->key)
	{
		element->rightChild = addElementInSubtree(key, element->rightChild, word);
	}
	return balance(element);
}


bool checkContainedAndAdd(int key, Set* set, char word[])
{
	SetElement* currentElement = set->root;
	while (currentElement != nullptr)
	{
		if (currentElement->key == key)
		{
			strcpy(currentElement->word, word);
			return true;
		}
		else if (currentElement->key > key)
		{
			currentElement = currentElement->leftChild;
		}
		else
		{
			currentElement = currentElement->rightChild;
		}
	}
	return false;
}


void addElement(int key, Set* set, char word[])
{
	if (!checkContainedAndAdd(key, set, word))
	{
		set->root = addElementInSubtree(key, set->root, word);
	}
}

SetElement* getMinSetElementFromRightSubtree(SetElement* element)
{
	if (element == nullptr)
	{
		return nullptr;
	}

	if (element->leftChild != nullptr)
	{
		return getMinSetElementFromRightSubtree(element->leftChild);
	}
	return element;
}

SetElement* deleteMinSetElementFromRightSubtree(SetElement* element)
{
	if (element == nullptr)
	{
		return nullptr;
	}
	if (element->leftChild == nullptr)
	{
		return element->rightChild;
	}
	element->leftChild = deleteMinSetElementFromRightSubtree(element->leftChild);
	return balance(element);
}

SetElement* deleteElementFromSubtree(int key, SetElement* element)
{
	if (element == nullptr)
	{
		return nullptr;
	}
	if (key < element->key)
	{
		element->leftChild = deleteElementFromSubtree(key, element->leftChild);
	}
	else if (key > element->key)
	{
		element->rightChild = deleteElementFromSubtree(key, element->rightChild);
	}
	else
	{
		SetElement* leftChild = element->leftChild;
		SetElement* rightChild = element->rightChild;
		if (rightChild == nullptr)
		{
			delete element;
			return leftChild;
		}
		SetElement* minElement = getMinSetElementFromRightSubtree(rightChild);
		minElement->rightChild = deleteMinSetElementFromRightSubtree(rightChild);
		minElement->leftChild = leftChild;
		delete element;
		return balance(minElement);
	}
	return balance(element);
}

bool deleteElement(int key, Set* set)
{
	if (set == nullptr)
	{
		return false;
	}

	if (isContained(key, set))
	{
		set->root = deleteElementFromSubtree(key, set->root);
		return true;
	}
	return false;
}

void deleteSubtree(SetElement* element)
{
	if (element == nullptr)
	{
		return;
	}
	deleteSubtree(element->leftChild);
	deleteSubtree(element->rightChild);
	delete element;
}

void deleteSet(Set* set)
{
	if (set == nullptr)
	{
		return;
	}
	deleteSubtree(set->root);
	delete set;
}