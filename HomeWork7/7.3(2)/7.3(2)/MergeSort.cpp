#include "MergeSort.h"
#include "List.h"

List* merge(List* leftList, List* rightList)
{
	List* list = createList();
	while (!empty(leftList) && !empty(rightList))
	{
		pushToNewList(list, leftList, rightList);
	}
	if (!empty(leftList))
	{
		transferLastValues(leftList, list);
	}
	if (!empty(rightList))
	{
		transferLastValues(rightList, list);
	}
	return list;
}

List* mergeSort(List* list)
{
	int size = takeListSize(list);
	if (size < 2)
	{
		return list;
	}
	List* leftList = createList();
	createNewLeftList(list, leftList, size);
	List* rightList = createList();
	createNewRightList(list, rightList, size);
	deleteList(list);
	leftList = mergeSort(leftList);
	rightList = mergeSort(rightList);
	return merge(leftList, rightList);
}
