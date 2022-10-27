using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Academits.Karetskas.TreeTask
{
    internal sealed class BinaryTree<T>
    {
        private enum ChildPosition
        {
            Left = 0,
            Right = 1
        }

        private TreeNode<T>? _root;
        private IComparer<T>? _comparer;

        public int Count { get; private set; }

        public BinaryTree() { }

        public BinaryTree(T? data) : this(data, null) { }

        public BinaryTree(T? data, IComparer<T>? comparer)
        {
            _root = new TreeNode<T>(data);
            _comparer = comparer;

            Count++;
        }

        private int Compare(T? data1, T? data2)
        {
            if (_comparer is not null)
            {
                return _comparer.Compare(data1, data2);
            }

            if (data1 is null && data2 is null)
            {
                return 0;
            }

            IComparable<T>? comparable;
            T? data;

            if (data1 is null)
            {
                comparable = data2 as IComparable<T>;

                CheckTypeIComparable(comparable, nameof(data2));

                data = data1;
            }
            else
            {
                comparable = data1 as IComparable<T>;

                CheckTypeIComparable(comparable, nameof(data1));

                data = data2;
            }

            return comparable!.CompareTo(data);
        }

        private void CheckTypeIComparable(IComparable<T>? comparable, string paramName)
        {
            if (comparable is null)
            {
                throw new ArgumentException("The specified deneric type did not implement the \"IComparable\" interface.", paramName);
            }
        }

        public void Add(T? data)
        {
            if (_root is null)
            {
                _root = new TreeNode<T>(data);
                Count++;

                return;
            }

            for (TreeNode<T>? currentNode = _root; currentNode is not null;)
            {
                if (Compare(data, currentNode.Data) < 0)
                {
                    if (currentNode.LeftChild is null)
                    {
                        currentNode.LeftChild = new TreeNode<T>(data);

                        break;
                    }

                    currentNode = currentNode.LeftChild;

                    continue;
                }

                if (currentNode.RightChild is null)
                {
                    currentNode.RightChild = new TreeNode<T>(data);

                    break;
                }

                currentNode = currentNode.RightChild;
            }

            Count++;
        }

        public bool Contains(T? data)
        {
            for (TreeNode<T>? currentNode = _root; currentNode is not null;)
            {
                int comparisonResult = Compare(data, currentNode.Data);

                if (comparisonResult < 0)
                {
                    currentNode = currentNode.LeftChild;

                    continue;
                }

                if (comparisonResult > 0)
                {
                    currentNode = currentNode.RightChild;

                    continue;
                }

                return true;
            }

            return false;
        }

        public bool Remove(T? data)
        {
            if (_root is null)
            {
                return false;
            }

            TreeNode<T>? nodeParent = null;
            ChildPosition childPosition = ChildPosition.Left;
            TreeNode<T>? nodeToRemove = null;

            for (TreeNode<T>? currentNode = _root; currentNode is not null;)
            {
                int comparisonResult = Compare(data, currentNode.Data);

                if (comparisonResult == 0)
                {
                    nodeToRemove = currentNode;

                    break;
                }

                nodeParent = currentNode;

                if (comparisonResult > 0)
                {
                    childPosition = ChildPosition.Right;

                    currentNode = currentNode.RightChild;

                    continue;
                }

                childPosition = ChildPosition.Left;

                currentNode = currentNode.LeftChild;
            }

            if (nodeToRemove is null)
            {
                return false;
            }

            if (nodeToRemove.ChildrenCount == 0)
            {
                RemoveNode(nodeParent, childPosition, null);
            }
            else if (nodeToRemove.ChildrenCount == 1)
            {
                RemoveNode(nodeParent, childPosition, nodeToRemove.LeftChild is null ? nodeToRemove.RightChild : nodeToRemove.LeftChild);
            }
            else
            {
                TreeNode<T>? minLeftNode = nodeToRemove.RightChild;
                TreeNode<T>? minLeftNodeParent = nodeToRemove;

                while (minLeftNode!.LeftChild is not null)
                {
                    minLeftNodeParent = minLeftNode;
                    minLeftNode = minLeftNode.LeftChild;
                }

                if (ReferenceEquals(minLeftNodeParent.RightChild, minLeftNode))
                {
                    RemoveNode(nodeParent, childPosition, minLeftNode);

                    minLeftNode.LeftChild = nodeToRemove.LeftChild;
                }
                else
                {
                    minLeftNodeParent.LeftChild = minLeftNode.RightChild;

                    RemoveNode(nodeParent, childPosition, minLeftNode);

                    minLeftNode.LeftChild = nodeToRemove.LeftChild;
                    minLeftNode.RightChild = nodeToRemove.RightChild;
                }
            }

            Count--;

            return true;
        }

        private void RemoveNode(TreeNode<T>? nodeParent, ChildPosition child, TreeNode<T>? node)
        {
            if (nodeParent is null)
            {
                _root = node;

                return;
            }

            if (child == ChildPosition.Left)
            {
                nodeParent.LeftChild = node;

                return;
            }

            nodeParent.RightChild = node;
        }

        public void BreadthFirstTraversal(Action<T?> action)
        {
            if (_root is null)
            {
                return;
            }

            Queue<TreeNode<T>?> queue = new Queue<TreeNode<T>?>(Count);

            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                TreeNode<T>? treeNode = queue.Dequeue();

                action(treeNode!.Data);

                foreach (TreeNode<T>? node in treeNode.Children())
                {
                    queue.Enqueue(node);
                }
            }
        }

        public void DepthFirstTraversal(Action<T?> action)
        {
            if (_root is null)
            {
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>(Count);

            stack.Push(_root);

            while (stack.Count > 0)
            {
                TreeNode<T> treeNode = stack.Pop();

                action(treeNode.Data);

                foreach (TreeNode<T>? node in treeNode.ChildrenInReverseOrder())
                {
                    stack.Push(node!);
                }
            }
        }

        public void RecursiveDepthFirstTraversal(Action<T?> action)
        {
            if (_root is null)
            {
                return;
            }

            RecursiveTraversal(_root!, action);
        }

        private void RecursiveTraversal(TreeNode<T> node, Action<T?> action)
        {
            action(node.Data);

            foreach (TreeNode<T>? child in node.Children())
            {
                RecursiveTraversal(child!, action);
            }
        }

        public override string ToString()
        {
            if (_root is null)
            {
                return "";
            }

            Queue<TreeNode<T>?> nodesQueue = new Queue<TreeNode<T>?>(Count);
            Queue<XElement> xmlNodesQueue = new Queue<XElement>(Count);

            string? elementContent = _root!.Data is null ? "NULL" : _root.Data.ToString();
            XElement xmlRoot = new XElement("root", new XElement("data", elementContent));

            nodesQueue.Enqueue(_root);
            xmlNodesQueue.Enqueue(xmlRoot);

            while (nodesQueue.Count > 0)
            {
                TreeNode<T> treeNode = nodesQueue.Dequeue()!;
                XElement xmlNode = xmlNodesQueue.Dequeue();

                if (treeNode.LeftChild is not null)
                {
                    elementContent = treeNode.LeftChild.Data is null ? "NULL" : treeNode.LeftChild.Data.ToString();
                    XAttribute data = new XAttribute("data", elementContent!);

                    XElement leftChildNode = new XElement("node_L", data);

                    xmlNode.Add(leftChildNode);

                    nodesQueue.Enqueue(treeNode.LeftChild);
                    xmlNodesQueue.Enqueue(leftChildNode);
                }

                if (treeNode.RightChild is not null)
                {
                    elementContent = treeNode.RightChild.Data is null ? "NULL" : treeNode.RightChild.Data.ToString();
                    XAttribute data = new XAttribute("data", elementContent!);

                    XElement rightChildNode = new XElement("node_R", data);

                    xmlNode.Add(rightChildNode);

                    nodesQueue.Enqueue(treeNode.RightChild);
                    xmlNodesQueue.Enqueue(rightChildNode);
                }
            }

            return xmlRoot.ToString();
        }
    }
}