using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _2._9._1
{
    public class GenericSet<T> : ISet<T> where T : IComparable
    {

        public int Count { private set; get; }

        public bool IsReadOnly => throw new NotImplementedException();

        private SetNode root = null;

        private class SetNode
        {
            public SetNode rightChild = null;
            public SetNode leftChild = null;
            public T value;

            public SetNode(T value)
            {
                this.value = value;
            }
        }

        public void CopyTo(T[] array, int position)
        {
            foreach (var element in this)
            {
                array[position] = element;
                position++;
            }
        }

        public void Clear() => root = null;

        public bool IsEmpty() => root ==  null;

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

        public bool Contains(T value)
        {
            var currentElement = CheckElementInTree(value);
            return currentElement != null;
        }

        private SetNode CheckElementInTree(T value)
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

        private void SetChild(SetNode parent, SetNode oldChild, SetNode newChild)
        {
            if (parent.rightChild == oldChild)
            {
                parent.rightChild = newChild;
                return;
            }
            parent.leftChild = newChild;
        }

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

        public void ExceptWith(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Remove(element);
            }
        }

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

        void ICollection<T>.Add(T value) => Add(value);

        bool ICollection<T>.Remove(T value) => Remove(value);

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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
