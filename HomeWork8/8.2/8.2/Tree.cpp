#include "Tree.h"
#include <stdio.h>

struct TreeElement
{
	char function;
	int value;
	TreeElement* parent = nullptr;
	TreeElement* rightChild = nullptr;
	TreeElement* leftChild = nullptr;
};

struct Tree
{
	TreeElement* root = nullptr;
};

Tree* createTree()
{
	return new Tree;
}

int createNumber(char string[], int *counter)
{
	int value = 0;
	while (string[*counter] >= '0' && string[*counter] <= '9')
	{
		value = value * 10 + (string[*counter] - '0');
		(*counter)++;
	}
	return value;
}

TreeElement* addElementInTree(char string[], int *counter, TreeElement* parent)
{
	if (string[*counter] == '\0')
	{
		return nullptr;
	}
	while (string[*counter] == '(' || string[*counter] == ')' || string[*counter] == ' ')
	{
		(*counter)++;
		if (string[*counter] == '\0')
		{
			return nullptr;
		}
	}
	if (string[*counter] >= '0' && string[*counter] <= '9')
	{
		const int value = createNumber(string, counter);
		return new TreeElement{ ' ', value, parent, nullptr, nullptr };
	}
	else
	{
		char function = string[*counter];
		(*counter)++;
		auto newElement = new TreeElement{ function, 0, parent, nullptr, nullptr };
		newElement->leftChild = addElementInTree(string, counter, newElement);
		newElement->rightChild = addElementInTree(string, counter, newElement);
		return newElement;
	}
}

void buildTree(Tree* tree, char string[])
{
	int counter = 0;
	tree->root = addElementInTree(string, &counter, tree->root);
}

void outputTreeElement(TreeElement* element)
{
	if (element == nullptr)
	{
		return;
	}
	if (element->function == ' ')
	{
		printf("%d ", element->value);
	}
	else
	{
		printf("%c ", element->function);
	}
	outputTreeElement(element->leftChild);
	outputTreeElement(element->rightChild);
}

void outputTree(Tree* tree)
{
	outputTreeElement(tree->root);
}

TreeElement* counting(TreeElement* element)
{
	if (element->function != ' ')
	{
		TreeElement* leftElement = counting(element->leftChild);
		TreeElement* rightElement = counting(element->rightChild);
		if (element->function == '+')
		{
			element->function = ' ';
			element->value = leftElement->value + rightElement->value;
		}
		if (element->function == '-')
		{
			element->function = ' ';
			element->value = leftElement->value - rightElement->value;
		}
		if (element->function == '*')
		{
			element->function = ' ';
			element->value = leftElement->value * rightElement->value;
		}
		if (element->function == '/')
		{
			element->function = ' ';
			element->value = leftElement->value / rightElement->value;
		}
	}
	return element;
}

void toCountResult(Tree* tree)
{
	counting(tree->root);
}

void deleteTreeElement(TreeElement* element)
{
	if (element->leftChild == nullptr && element->rightChild == nullptr)
	{
		delete element;
	}
	else
	{
		if (element->leftChild != nullptr)
		{
			deleteTreeElement(element->leftChild);
		}
		if (element->rightChild != nullptr)
		{
			deleteTreeElement(element->rightChild);
		}
		delete element;
	}
}
int getValueOfRoot(Tree* tree)
{
	return tree->root->value;
}

void deleteTree(Tree* tree)
{
	deleteTreeElement(tree->root);
	delete tree;
}

