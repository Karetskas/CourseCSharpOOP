using System.Collections.Generic;

namespace Academits.Karetskas.TreeTask
{
    internal sealed class TreeNode<T>
    {
        private TreeNode<T>? _leftChild;
        private TreeNode<T>? _rightChild;

        public int Count { get; private set; }

        public TreeNode<T>? LeftChild
        {
            get => _leftChild;

            set
            {
                if (_leftChild is null && value is not null)
                {
                    Count++;
                }
                else if (_leftChild is not null && value is null)
                {
                    Count--;
                }

                _leftChild = value;
            }
        }

        public TreeNode<T>? RightChild
        {
            get => _rightChild;

            set
            {
                if (_rightChild is null && value is not null)
                {
                    Count++;
                }
                else if (_rightChild is not null && value is null)
                {
                    Count--;
                }

                _rightChild = value;
            }
        }

        public T? Data { get; set; }

        public TreeNode(T? data)
        {
            Data = data;
        }

        public TreeNode(TreeNode<T>? leftChild, TreeNode<T>? rightChild, T? data)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            Data = data;
        }

        public IEnumerable<TreeNode<T>?> Children()
        {
            yield return LeftChild;
            yield return RightChild;
        }

        public IEnumerable<TreeNode<T>?> ChildrenInReverseOrder()
        {
            yield return RightChild;
            yield return LeftChild;
        }
    }
}
