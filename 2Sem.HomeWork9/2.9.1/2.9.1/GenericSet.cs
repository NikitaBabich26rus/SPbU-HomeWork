using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _2._9._1
{
    /// <summary>
    /// Unbalanced binary tree class.
    /// </summary>
    /// <typeparam name="T">Elements type</typeparam>
    public class GenericSet<T> : ISet<T> where T : IComparable
    {
        private SetNode root = null;

        /// <summary>
        /// Elements amount in set.
        /// </summary>
        public int Count { private set; get; }

        /// <summary>
        /// Checks read-only or not.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Set element class.
        /// </summary>
        private class SetNode
        {
            public SetNode rightChild = null;
            public SetNode leftChild = null;
            public T value;

            /// <summary>
            /// Set element constructor.
            /// </summary>
            /// <param name="value"></param>
            public SetNode(T value)
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Copy all elements from set to array.
        /// </summary>
        /// <param name="array">Array for set elements</param>
        /// <param name="position">Start index in array</param>
        public void CopyTo(T[] array, int position)
        {
            foreach (var element in this)
            {
                array[position] = element;
                position++;
            }
        }

        /// <summary>
        /// Set clear.
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Add new element in set.
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <returns>True - succeeded, false - otherwise</returns>
        public bool Add(T value)
        {
            if (Contains(value))
            {
                return false;
            }
            Count++;
            if (root == null)
            {
                root = new SetNode(value);
                return true; 
            }
            SetNode currentNode = root;
            while (true)
            {
                if (value.CompareTo(currentNode.value) > 0)
                {
                    if (currentNode.rightChild == null)
                    {
                        currentNode.rightChild = new SetNode(value);
                        return true;
                    }
                    currentNode = currentNode.rightChild;
                }
                else if (value.CompareTo(currentNode.value) < 0)
                {
                    if (currentNode.leftChild == null)
                    {
                        currentNode.leftChild = new SetNode(value);
                        return true;
                    }
                    currentNode = currentNode.leftChild;
                }
            }
        }

        /// <summary>
        /// Check set for element contains
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <returns>True - contained, false - otherwise</returns>
        public bool Contains(T value)
        {
            var currentElement = GetElementFromSet(value);
            return currentElement != null;
        }

        /// <summary>
        /// Get an element by its value
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <returns>Element</returns>
        private SetNode GetElementFromSet(T value)
        {
            if (root == null)
            {
                return null;
            }
            var currentNode = root;
            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.value) > 0)
                {
                    currentNode = currentNode.rightChild;
                }
                else if (value.CompareTo(currentNode.value) < 0)
                {
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    break;
                }
            }
            return currentNode;
        }

        /// <summary>
        /// Set new child in set.
        /// </summary>
        /// <param name="parent">Previous element in set</param>
        /// <param name="oldChild">Old next element</param>
        /// <param name="newChild">New next element</param>
        private void SetChild(SetNode parent, SetNode oldChild, SetNode newChild)
        {
            if (parent.rightChild == oldChild)
            {
                parent.rightChild = newChild;
                return;
            }
            parent.leftChild = newChild;
        }

        /// <summary>
        /// Get element and its parent.
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <param name="parent">Previous element</param>
        /// <returns>Element</returns>
        private SetNode GetElementInTreeAndParent(T value, ref SetNode parent)
        {
            SetNode currentNode = root;
            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.value) > 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.rightChild;
                }
                else if (value.CompareTo(currentNode.value) < 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    return currentNode;
                }
            }
            return null;
        }

        /// <summary>
        /// Get max element in left branch.
        /// </summary>
        /// <param name="element">Start branch</param>
        /// <param name="parent">Previous element</param>
        /// <returns></returns>
        private SetNode FindLeftMax(SetNode element, ref SetNode parent)
        {
            element = element.leftChild;
            while (element.rightChild != null)
            {
                parent = element;
                element = element.rightChild;
            }
            return element;
        }

        /// <summary>
        /// Remove element from set.
        /// </summary>
        /// <param name="value">Element`s value</param>
        /// <returns>True - succeded, false - otherwise</returns>
        public bool Remove(T value)
        {
            SetNode parent = null;
            var elementForDeletion = GetElementInTreeAndParent(value, ref parent);
            if (elementForDeletion == null)
            {
                return false;
            }
            Count--;
            if (elementForDeletion.leftChild == null && elementForDeletion.rightChild == null)
            {
                if (root == elementForDeletion)
                {
                    root = null;
                    return true;
                }
                SetChild(parent, elementForDeletion, null);
                elementForDeletion = null;
                return true;
            }
            if (elementForDeletion.leftChild == null && elementForDeletion.rightChild != null)
            {
                if (root == elementForDeletion)
                {
                    root = elementForDeletion.rightChild;
                    elementForDeletion = null;
                    return true;
                }
                SetChild(parent, elementForDeletion, elementForDeletion.rightChild);
                elementForDeletion = null;
                return true;
            }
            if (elementForDeletion.rightChild == null && elementForDeletion.leftChild != null)
            {
                if (root == elementForDeletion)
                {
                    root = elementForDeletion.leftChild;
                    elementForDeletion = null;
                    return true;
                }
                SetChild(parent, elementForDeletion, elementForDeletion.leftChild);
                elementForDeletion = null;
                return true;
            }
            var parentOfChangeElement = elementForDeletion;
            var changeElement = FindLeftMax(elementForDeletion, ref parentOfChangeElement);
            if (root == elementForDeletion)
            {
                if (elementForDeletion.leftChild == changeElement)
                {
                    root = changeElement;
                    changeElement.rightChild = elementForDeletion.rightChild;
                    elementForDeletion = null;
                    return true;
                }
                root = changeElement;
                parentOfChangeElement.rightChild = changeElement.leftChild;
                changeElement.leftChild = elementForDeletion.leftChild;
                changeElement.rightChild = elementForDeletion.rightChild;
                elementForDeletion = null;
                return true;
            }
            if (elementForDeletion.leftChild == changeElement)
            {
                SetChild(parent, elementForDeletion, changeElement);
                changeElement.rightChild = elementForDeletion.rightChild;
                elementForDeletion = null;
                return true;
            }
            parentOfChangeElement.rightChild = changeElement.leftChild;
            SetChild(parent, elementForDeletion, changeElement);
            changeElement.leftChild = elementForDeletion.leftChild;
            changeElement.rightChild = elementForDeletion.rightChild;
            elementForDeletion = null;
            return true;
        }

        /// <summary>
        ///  Removes all elements in the collection from the current set
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        public void ExceptWith(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        public void IntersectWith(IEnumerable<T> collection)
        {
            var list = new List<T>();
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    list.Add(element);
                }
            }
            foreach (var element in list)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified collection.
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True - proper subset, false - otherwise</returns>
        public bool IsProperSubsetOf(IEnumerable<T> collection)
        {
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the current set is a proper superset of a specified collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True - proper superset, false - otherwise</returns>
        public bool IsProperSupersetOf(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True - subset, false - otherwise</returns>
        public bool IsSubsetOf(IEnumerable<T> collection)
        {
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True - superset, false - otherwise</returns>
        public bool IsSupersetOf(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the current set overlaps with the collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True if the current set and collection share at least one common element, false - otherwise</returns>
        public bool Overlaps(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        /// <returns>True - contain the same elements, false - otherwise</returns>
        public bool SetEquals(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        public void SymmetricExceptWith(IEnumerable<T> collection)
        {
            var list = new List<T>();
            foreach (var element in collection)
            {
                if (Contains(element))
                {
                    list.Add(element);
                }
                else
                {
                    Add(element);
                }
            }
            foreach (var element in list)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set in the collection
        /// </summary>
        /// <param name="collection">Element`s collection</param>
        public void UnionWith(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    Add(element);
                }
            }
        }

        /// <summary>
        /// Add element in collection
        /// </summary>
        /// <param name="value">Element`s value</param>
        void ICollection<T>.Add(T value) => Add(value);

        /// <summary>
        /// Set dfs.
        /// </summary>
        /// <returns>Set elements</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (root == null)
            {
                yield break;
            }
            var stack = new Stack<SetNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.rightChild != null)
                {
                    stack.Push(node.rightChild);
                }
                if (node.leftChild != null)
                {
                    stack.Push(node.leftChild);
                }
                yield return node.value;
            }
        }

        /// <summary>
        /// Get enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
