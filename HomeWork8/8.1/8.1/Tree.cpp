#include "Tree.h"
#include <cstring>
#include <stdio.h>
#include <locale.h>

struct Tree
{
	TreeElement* head = nullptr;
};

struct TreeElement
{
	int key = 0;
	char word[sizeOfWord];
	TreeElement* rightChild = nullptr;
	TreeElement* leftChild = nullptr;
};

Tree* create()
{
	return new Tree;
}

bool empty(Tree* tree)
{
	return tree->head == nullptr;
}

void deleteElement(TreeElement* element)
{
	element->key = 0;
	element->leftChild = nullptr;
	element->rightChild = nullptr;
	delete element;
}

void push(Tree* tree, int key, char word[])
{
	if (empty(tree))
	{
		tree->head = new TreeElement;
		tree->head->key = key;
		strcpy(tree->head->word, word);
		return;
	}
	TreeElement* helpElement = tree->head;
	while (true)
	{
		if (key > helpElement->key)
		{
			if (helpElement->rightChild == nullptr)
			{
				helpElement->rightChild = new TreeElement;
				helpElement->rightChild->key = key;
				strcpy(helpElement->rightChild->word, word);
				break;
			}
			helpElement = helpElement->rightChild;
		}
		else if (key < helpElement->key)
		{
			if (helpElement->leftChild == nullptr)
			{
				helpElement->leftChild = new TreeElement;
				helpElement->leftChild->key = key;
				strcpy(helpElement->leftChild->word, word);
				break;
			}
			helpElement = helpElement->leftChild;
		}
		else
		{
			strcpy(helpElement->word, word);
			break;
		}
	}
}

TreeElement* checkElementInTree(Tree* tree, int key)
{
	TreeElement* helpElement = tree->head;
	while (helpElement != nullptr)
	{
		if (key > helpElement->key)
		{
			helpElement = helpElement->rightChild;
		}
		else if (key < helpElement->key)
		{
			helpElement = helpElement->leftChild;
		}
		else
		{
			break;
		}
	}
	return helpElement;
}

bool checkKeyInTree(Tree* tree, int key)
{
	TreeElement* findElement = checkElementInTree(tree, key);
	if (findElement == nullptr)
	{
		return false;
	}
	return true;
}

char* checkWordInTree(Tree* tree, int key)
{
	TreeElement* findElement = checkElementInTree(tree, key);
	if (findElement == nullptr)
	{
		return nullptr;
	}
	return findElement->word;
}

TreeElement* checkElementInTreeAndParent(Tree* tree, int key, TreeElement** parent)
{
	TreeElement* helpElement = tree->head;
	while (helpElement != nullptr)
	{
		if (key > helpElement->key)
		{
			*parent = helpElement;
			helpElement = helpElement->rightChild;
		}
		else if (key < helpElement->key)
		{
			*parent = helpElement;
			helpElement = helpElement->leftChild;
		}
		else
		{
			return helpElement;
		}
	}
	return nullptr;
}

TreeElement* findLeftMax(TreeElement* element, TreeElement** parent)
{
	element = element->leftChild;
	while (element->rightChild != nullptr)
	{
		*parent = element;
		element = element->rightChild;
	}
	return element;
}

void setChild(TreeElement* parent, TreeElement* oldChild, TreeElement* newChild)
{
	if (parent->rightChild == oldChild)
	{
		parent->rightChild = newChild;
	}
	else
	{
		parent->leftChild = newChild;
	}
}

void checkElementForDelete(Tree* tree, int key)
{
	TreeElement* parent = nullptr;
	TreeElement* elementForDeletion = checkElementInTreeAndParent(tree, key, &parent);
	if (elementForDeletion == nullptr)
	{
		return;
	}
	if (elementForDeletion->leftChild == nullptr && elementForDeletion->rightChild == nullptr)
	{
		if (tree->head == elementForDeletion)
		{
			deleteElement(tree->head);
			tree->head = nullptr;
			return;
		}
		setChild(parent, elementForDeletion, nullptr);
		deleteElement(elementForDeletion);
		return;
	}
	if (elementForDeletion->leftChild == nullptr && elementForDeletion->rightChild != nullptr)
	{
		if (tree->head == elementForDeletion)
		{
			tree->head = elementForDeletion->rightChild;
			deleteElement(elementForDeletion);
			return;
		}
		setChild(parent, elementForDeletion, elementForDeletion->rightChild);
		deleteElement(elementForDeletion);
		return;
	}
	if (elementForDeletion->rightChild == nullptr && elementForDeletion->leftChild != nullptr)
	{
		if (tree->head == elementForDeletion)
		{
			tree->head = elementForDeletion->leftChild;
			deleteElement(elementForDeletion);
			return;
		}  
		setChild(parent, elementForDeletion, elementForDeletion->leftChild);
		deleteElement(elementForDeletion);
		return;
	}
	TreeElement* parentOfÑhangeElement = elementForDeletion;
	TreeElement* changeElement = findLeftMax(elementForDeletion, &parentOfÑhangeElement);
	if (tree->head == elementForDeletion)
	{
		if (elementForDeletion->leftChild == changeElement)
		{
			tree->head = changeElement;
			changeElement->rightChild = elementForDeletion->rightChild;
			deleteElement(elementForDeletion);
			return;
		}
		tree->head = changeElement;
		parentOfÑhangeElement->rightChild = changeElement->leftChild;
		changeElement->leftChild = elementForDeletion->leftChild;
		changeElement->rightChild = elementForDeletion->rightChild;
		deleteElement(elementForDeletion);
		return;
	}
	if (elementForDeletion->leftChild == changeElement)
	{
		setChild(parent, elementForDeletion, changeElement);
		changeElement->rightChild = elementForDeletion->rightChild;
		deleteElement(elementForDeletion);
		return;
	}
	parentOfÑhangeElement->rightChild = changeElement->leftChild;
	setChild(parent, elementForDeletion, changeElement);
	changeElement->leftChild = elementForDeletion->leftChild;
	changeElement->rightChild = elementForDeletion->rightChild;
	deleteElement(elementForDeletion);
}

void deleteTree(Tree* tree)
{
	while (!empty(tree))
	{
		checkElementForDelete(tree, tree->head->key);
	}
	delete tree;
}