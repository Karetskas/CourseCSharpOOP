using System.Collections.Generic;

namespace Academits.Karetskas.TreeTask
{
    internal sealed class TreeNode<T>
    {
        public int ChildrenCount
        {
            get
            {
                int childrenCount = 0;

                if (LeftChild is not null)
                {
                    childrenCount++;
                }

                if (RightChild is not null)
                {
                    childrenCount++;
                }

                return childrenCount;
            }
        }

        public TreeNode<T>? LeftChild { get; set; }

        public TreeNode<T>? RightChild { get; set; }

        public T? Data { get; set; }

        public TreeNode(T? data)
        {
            Data = data;
        }

        public TreeNode(T? data, TreeNode<T>? leftChild, TreeNode<T>? rightChild)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            Data = data;
        }

        public IEnumerable<TreeNode<T>?> Children()
        {
            if (LeftChild is not null)
            {
                yield return LeftChild;
            }

            if (RightChild is not null)
            {
                yield return RightChild;
            }
        }

        public IEnumerable<TreeNode<T>?> ChildrenInReverseOrder()
        {
            if (RightChild is not null)
            {
                yield return RightChild;
            }

            if (LeftChild is not null)
            {
                yield return LeftChild;
            }
        }
    }
}
