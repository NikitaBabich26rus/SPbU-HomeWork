#include "MergeSort.h"
#include "List.h"

List* merge(List* leftList, List* rightList)
{
	List* list = createList();
	while (!empty(leftList) || !empty(rightList))
	{
		pushToNewList(list, leftList, rightList);
		if (!empty(leftList) && empty(rightList))
		{
			transferLastValues(leftList, list);
		}
		if (empty(leftList) && !empty(rightList))
		{
			transferLastValues(rightList, list);
		}
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
	List* leftList = createNewLeftlist(list, size);
	List* rightList = createNewRightList(list, size);
	leftList = mergeSort(leftList);
	rightList = mergeSort(rightList);

	//delete

	return merge(leftList, rightList);
}
