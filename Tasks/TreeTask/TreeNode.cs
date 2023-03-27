using System.Collections.Generic;
using System.Linq;

namespace Academits.Karetskas.TreeTask
{
    internal sealed class TreeNode<T>
    {
        public int ChildrenCount => Children().Count();

        public TreeNode<T>? LeftChild { get; set; }

        public TreeNode<T>? RightChild { get; set; }

        public T Data { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }

        public IEnumerable<TreeNode<T>> Children()
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

        public IEnumerable<TreeNode<T>> ChildrenInReverseOrder()
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
