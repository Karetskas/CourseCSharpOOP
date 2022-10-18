using System;
using System.Text;
using System.Collections.Generic;

namespace Academits.Karetskas.TreeTask
{
    internal sealed class BinaryTree<T>
    {
        private enum NodeChildren
        {
            LeftChild = 0,
            RightChild = 1
        }

        private TreeNode<T>? _root;
        private IComparer<T>? _comparer;

        public int Count { get; private set; }

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

            IComparable<T>? comparable = data1 as IComparable<T>;

            if (comparable is null)
            {
                throw new ArgumentException("The specified deneric type did not implement the \"IComparable\" interface.", nameof(comparable));
            }

            return comparable.CompareTo(data2);
        }

        private TreeNode<T>? FindNode(Func<TreeNode<T>, (bool, TreeNode<T>?)> match)
        {
            for (TreeNode<T>? currentNode = _root; currentNode is not null;)
            {
                (bool isFoundNode, TreeNode<T>? nextNodeToSearchFor) functionResult = match(currentNode);

                if (functionResult.isFoundNode)
                {
                    return functionResult.nextNodeToSearchFor;
                }

                currentNode = functionResult.nextNodeToSearchFor;
            }

            return null;
        }

        public void Add(T? data)
        {
            if (_root is null)
            {
                _root = new TreeNode<T>(data);
                Count++;

                return;
            }

            FindNode((TreeNode<T> treeNode) =>
            {
                if (Compare(data, treeNode.Data) < 0)
                {
                    return CreateNewNode(treeNode, data, NodeChildren.LeftChild);
                }

                return CreateNewNode(treeNode, data, NodeChildren.RightChild);
            });

            Count++;
        }

        private (bool, TreeNode<T>) CreateNewNode(TreeNode<T> nodeParent, T? data, NodeChildren nodeType)
        {
            TreeNode<T>? child = nodeType == NodeChildren.LeftChild ? nodeParent.LeftChild : nodeParent.RightChild;

            bool isNullNode = false;

            if (child is null)
            {
                child = new TreeNode<T>(data);

                isNullNode = true;
            }

            return (isNullNode, nodeType == NodeChildren.LeftChild ? nodeParent.LeftChild = child : nodeParent.RightChild = child);
        }

        public bool Contains(T? data)
        {
            bool isContains = false;

            FindNode((TreeNode<T> treeNode) =>
            {
                if (Compare(data, treeNode.Data) < 0)
                {
                    return (false, treeNode.LeftChild);
                }

                if (Compare(data, treeNode.Data) > 0)
                {
                    return (false, treeNode.RightChild);
                }

                isContains = true;

                return (true, treeNode);
            });

            return isContains;
        }

        public bool Remove(T? data)
        {
            if (_root is null)
            {
                return false;
            }

            TreeNode<T>? nodeParent = null;
            NodeChildren child = NodeChildren.LeftChild;

            TreeNode<T>? nodeToRemove = FindNode((TreeNode<T> treeNode) =>
            {
                int comparisonResult = Compare(data, treeNode.Data);

                if (comparisonResult == 0)
                {
                    return (true, treeNode);
                }

                nodeParent = treeNode;

                if (comparisonResult > 0)
                {
                    child = NodeChildren.RightChild;

                    return (false, treeNode.RightChild);
                }

                child = NodeChildren.LeftChild;

                return (false, treeNode.LeftChild);
            });

            if (nodeToRemove is null)
            {
                return false;
            }

            if (nodeToRemove.Count == 0)
            {
                RemoveNode(nodeParent, child, () => null, () => null);
            }
            else if (nodeToRemove.Count == 1)
            {
                RemoveNode(nodeParent, child,
                    () => _root.LeftChild is null ? _root.RightChild : _root.LeftChild,
                    () => nodeToRemove.LeftChild is null ? nodeToRemove.RightChild : nodeToRemove.LeftChild);
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
                    RemoveNode(nodeParent, child, () => minLeftNode, () => minLeftNode);

                    minLeftNode.LeftChild = nodeToRemove.LeftChild;
                }
                else
                {
                    minLeftNodeParent.LeftChild = minLeftNode.RightChild;

                    RemoveNode(nodeParent, child, () => minLeftNode, () => minLeftNode);

                    minLeftNode.LeftChild = nodeToRemove.LeftChild;
                    minLeftNode.RightChild = nodeToRemove.RightChild;
                }

                nodeToRemove = null;
            }

            Count--;

            return true;
        }

        private void RemoveNode(TreeNode<T>? nodeParent, NodeChildren child, Func<TreeNode<T>?> actionForRoot, Func<TreeNode<T>?> actionForNode)
        {
            if (nodeParent is null)
            {
                _root = actionForRoot();

                return;
            }

            if (child == NodeChildren.LeftChild)
            {
                nodeParent.LeftChild = actionForNode();

                return;
            }

            nodeParent.RightChild = actionForNode();
        }

        public void BreadthFirstTraversal(Action<T?> action)
        {
            CheckRoot();

            Queue<TreeNode<T>?> queue = new Queue<TreeNode<T>?>(Count);

            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                TreeNode<T>? treeNode = queue.Dequeue();

                if (treeNode is null)
                {
                    continue;
                }

                action(treeNode.Data);

                foreach (TreeNode<T>? node in treeNode.Children())
                {
                    if (node is not null)
                    {
                        queue.Enqueue(node);
                    }
                }
            }
        }

        public void DepthFirstTraversal(Action<T?> action)
        {
            CheckRoot();

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>(Count);

            for (stack.Push(_root!); stack.Count > 0;)
            {
                TreeNode<T> treeNode = stack.Pop();

                action(treeNode.Data);

                foreach (TreeNode<T>? node in treeNode.ChildrenInReverseOrder())
                {
                    if (node is not null)
                    {
                        stack.Push(node);
                    }
                }
            }
        }

        public void RecursiveDepthFirstTraversal(Action<T?> action)
        {
            CheckRoot();

            RecursiveTraversal(_root!, action);
        }

        private void RecursiveTraversal(TreeNode<T> node, Action<T?> action)
        {
            action(node.Data);

            foreach (TreeNode<T>? child in node.Children())
            {
                if (child is null)
                {
                    continue;
                }

                RecursiveTraversal(child, action);
            }
        }

        private void CheckRoot()
        {
            if (_root is null)
            {
                throw new ArgumentNullException(nameof(_root), "The root tree is null.");
            }
        }

        public override string ToString()
        {
            int nodeId = -1;
            int tabsCount = 0;
            StringBuilder xmlTree = new StringBuilder();

            if (!InsertIntoXMLTree(_root, ref xmlTree, ref nodeId, 0, tabsCount, true))
            {
                return "";
            }

            Queue<TreeNode<T>?> nodesQueue = new Queue<TreeNode<T>?>(Count);
            Queue<int> tabsQueue = new Queue<int>(Count);

            nodesQueue.Enqueue(_root);
            tabsQueue.Enqueue(tabsCount);

            for (int currentId = 0; currentId < Count; currentId++)
            {
                tabsCount = tabsQueue.Dequeue();

                string text = xmlTree.ToString();
                int index = text.IndexOf($"{new string('\t', tabsCount)}</node>", text.IndexOf($"<node id=\"{currentId}\">"));

                TreeNode<T> treeNode = nodesQueue.Dequeue()!;

                tabsCount++;

                int xmlTreeLength = xmlTree.Length;

                bool isLeftChild = true;

                foreach (TreeNode<T>? node in treeNode.Children())
                {
                    if (InsertIntoXMLTree(node, ref xmlTree, ref nodeId, index, tabsCount, false))
                    {
                        nodesQueue.Enqueue(node);
                        tabsQueue.Enqueue(tabsCount);

                        if (isLeftChild)
                        {
                            index += xmlTree.Length - xmlTreeLength;
                        }
                    }

                    isLeftChild = false;
                }
            }

            return xmlTree.ToString();
        }

        private bool InsertIntoXMLTree(TreeNode<T>? treeNode, ref StringBuilder xmlTree, ref int nodeId, int index, int tabsCount, bool isRoot)
        {
            if (treeNode is null)
            {
                return false;
            }

            nodeId++;

            string elementContent = treeNode.Data is null ? "NULL" : treeNode.Data.ToString()!;

            string tagTabs = new string('\t', tabsCount);

            string tag = $"{tagTabs}<node id=\"{nodeId}\">{Environment.NewLine}"
                + $"{tagTabs}\t<data>{elementContent}</data>{Environment.NewLine}"
                + $"{tagTabs}</node>{Environment.NewLine}";

            if (isRoot)
            {
                tag = tag.Remove(tag.LastIndexOf(Environment.NewLine));
            }

            xmlTree.Insert(index, tag);

            return true;
        }
    }
}