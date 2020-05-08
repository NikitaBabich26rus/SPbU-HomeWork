
#include <stdio.h>
#include "Tree.h"

const int sizeOfString = 1000;

bool tests()
{
	Tree* tree = createTree();
	char TestString[15]{ "(/ (+ 1 1) 2)" };
	buildTree(tree, TestString);
	toCountResult(tree);
	if (getValueOfRoot(tree) == 1)
	{
		deleteTree(tree);
		return true;
	}
	deleteTree(tree);
	return false;
}

int main()
{
	if (!tests())
	{
		return -1;
	}
	Tree* tree = createTree();
	char string[sizeOfString]{};

	FILE* file = fopen("Input.txt", "r");
	fgets(string, 100, file);
	fclose(file);

	buildTree(tree, string);
	toCountResult(tree);
	printf("Program result : ");
	printf("%d\n", getValueOfRoot(tree));

	deleteTree(tree);
	return 0;
}

