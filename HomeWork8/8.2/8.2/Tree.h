#pragma once

struct Tree;

Tree* createTree();

void buildTree(Tree* tree, char string[]);

void outputTree(Tree* tree);

void toCountResult(Tree* tree);

int getValueOfRoot(Tree* tree);

void deleteTree(Tree* tree);