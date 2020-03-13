#include "Tree.h"
#include <cstring>
#include <stdio.h>
#include <locale.h>

struct TreeElement
{
	int key = 0;
	char word[sizeOfWord];
	TreeElement* rightChild = nullptr;
	TreeElement* leftChild = nullptr;
};

struct Tree
{
	TreeElement* root = nullptr;
};

Tree* create()
{
	return new Tree;
}

bool empty(Tree* tree)
{
	return tree->root == nullptr;
}

void push(Tree* tree, int key, char word[])
{
	if (empty(tree))
	{
		tree->root = new TreeElement;
		tree->root->key = key;
		strcpy(tree->root->word, word);
		return;
	}
	TreeElement* helpElement = tree->root;
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
	TreeElement* helpElement = tree->root;
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

bool isKeyInTree(Tree* tree, int key)
{
	TreeElement* findElement = checkElementInTree(tree, key);
	return findElement != nullptr;
}

char* getWordInTree(Tree* tree, int key)
{
	TreeElement* findElement = checkElementInTree(tree, key);
	if (findElement == nullptr)
	{
		return nullptr;
	}
	return findElement->word;
}

TreeElement* getElementInTreeAndParent(Tree* tree, int key, TreeElement** parent)
{
	TreeElement* helpElement = tree->root;
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
	TreeElement* elementForDeletion = getElementInTreeAndParent(tree, key, &parent);
	if (elementForDeletion == nullptr)
	{
		return;
	}
	if (elementForDeletion->leftChild == nullptr && elementForDeletion->rightChild == nullptr)
	{
		if (tree->root == elementForDeletion)
		{
			delete(tree->root);
			tree->root = nullptr;
			return;
		}
		setChild(parent, elementForDeletion, nullptr);
		delete(elementForDeletion);
		return;
	}
	if (elementForDeletion->leftChild == nullptr && elementForDeletion->rightChild != nullptr)
	{
		if (tree->root == elementForDeletion)
		{
			tree->root = elementForDeletion->rightChild;
			delete(elementForDeletion);
			return;
		}
		setChild(parent, elementForDeletion, elementForDeletion->rightChild);
		delete(elementForDeletion);
		return;
	}
	if (elementForDeletion->rightChild == nullptr && elementForDeletion->leftChild != nullptr)
	{
		if (tree->root == elementForDeletion)
		{
			tree->root = elementForDeletion->leftChild;
			delete(elementForDeletion);
			return;
		}  
		setChild(parent, elementForDeletion, elementForDeletion->leftChild);
		delete(elementForDeletion);
		return;
	}
	TreeElement* parentOfChangeElement = elementForDeletion;
	TreeElement* changeElement = findLeftMax(elementForDeletion, &parentOfChangeElement);
	if (tree->root == elementForDeletion)
	{
		if (elementForDeletion->leftChild == changeElement)
		{
			tree->root = changeElement;
			changeElement->rightChild = elementForDeletion->rightChild;
			delete(elementForDeletion);
			return;
		}
		tree->root = changeElement;
		parentOfChangeElement->rightChild = changeElement->leftChild;
		changeElement->leftChild = elementForDeletion->leftChild;
		changeElement->rightChild = elementForDeletion->rightChild;
		delete(elementForDeletion);
		return;
	}
	if (elementForDeletion->leftChild == changeElement)
	{
		setChild(parent, elementForDeletion, changeElement);
		changeElement->rightChild = elementForDeletion->rightChild;
		delete(elementForDeletion);
		return;
	}
	parentOfChangeElement->rightChild = changeElement->leftChild;
	setChild(parent, elementForDeletion, changeElement);
	changeElement->leftChild = elementForDeletion->leftChild;
	changeElement->rightChild = elementForDeletion->rightChild;
	delete(elementForDeletion);
}

void deleteTree(Tree* tree)
{
	while (!empty(tree))
	{
		checkElementForDelete(tree, tree->root->key);
	}
	delete tree;
}