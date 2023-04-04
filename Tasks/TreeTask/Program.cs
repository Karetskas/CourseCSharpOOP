using System;

namespace Academits.Karetskas.TreeTask
{
    internal class Program
    {
        static void Main()
        {
            BinaryTree<int> searchTree = GetBinaryTree();
            string titleForSearchTree = "Search for nodes in a binary tree with values of 100 and 1000.";
            string textForSearchTree = $"Number 100 - {searchTree.Contains(100)};{Environment.NewLine}Number 1000 - {searchTree.Contains(1000)}";
            PrintToConsole(searchTree, titleForSearchTree, textForSearchTree, ConsoleColor.Green);

            BinaryTree<int> notEmptyTree = GetBinaryTree();

            BinaryTree<int> emptyTree = new BinaryTree<int>(1);
            emptyTree.Remove(1);

            string title = "Count of nodes in the binary trees.";
            string text = $"Count of nodes in the {nameof(notEmptyTree)} = {notEmptyTree.Count};{Environment.NewLine}"
                          + $"Count of nodes in the {nameof(emptyTree)} = {emptyTree.Count}.";
            PrintToConsole(notEmptyTree, title, text, ConsoleColor.Red);

            BinaryTree<int> binaryTreeBreadthFirstTraversal = GetBinaryTree();
            string titleForTreeBreadthFirstTraversal = "Breadth-first traversal of binary tree.";
            string textForTreeBreadthFirstTraversal = "List of nodes: ";
            binaryTreeBreadthFirstTraversal.TraverseInBreadth(data => textForTreeBreadthFirstTraversal += data + ", ");
            textForTreeBreadthFirstTraversal = textForTreeBreadthFirstTraversal.Remove(textForTreeBreadthFirstTraversal.Length - 2);
            PrintToConsole(binaryTreeBreadthFirstTraversal, titleForTreeBreadthFirstTraversal, textForTreeBreadthFirstTraversal, ConsoleColor.Blue);

            BinaryTree<int> binaryTreeDepthFirstTraversal = GetBinaryTree();
            string titleForTreeDepthFirstTraversal = "Depth first traversal of binary tree.";
            string textForTreeDepthFirstTraversal = "List of nodes: ";
            binaryTreeDepthFirstTraversal.TraverseInDepth(data => textForTreeDepthFirstTraversal += data + ", ");
            textForTreeDepthFirstTraversal = textForTreeDepthFirstTraversal.Remove(textForTreeDepthFirstTraversal.Length - 2);
            PrintToConsole(binaryTreeDepthFirstTraversal, titleForTreeDepthFirstTraversal, textForTreeDepthFirstTraversal, ConsoleColor.Yellow);

            BinaryTree<int> binaryTreeRecursiveDepthFirstTraversal = GetBinaryTree();
            string titleForRecursiveDepthFirstTraversal = "Recursive depth first traversal of binary tree.";
            string textForRecursiveDepthFirstTraversal = "List of nodes * 2: ";
            binaryTreeRecursiveDepthFirstTraversal.TraverseBinaryTreeRecursivelyInDepth(data => textForRecursiveDepthFirstTraversal += data * 2 + ", ");
            textForRecursiveDepthFirstTraversal = textForRecursiveDepthFirstTraversal.Remove(textForRecursiveDepthFirstTraversal.Length - 2);
            PrintToConsole(binaryTreeRecursiveDepthFirstTraversal, titleForRecursiveDepthFirstTraversal, textForRecursiveDepthFirstTraversal, ConsoleColor.DarkYellow);

            BinaryTree<int> binaryTreeRemovingRoot = new BinaryTree<int>(2);

            binaryTreeRemovingRoot.Add(1);
            binaryTreeRemovingRoot.Add(3);

            string titleTreeRemovingRoot = "Deleting a non-existent node.";
            string textTreeRemovingRoot = $"The node = 4 has been removed => {binaryTreeRemovingRoot.Remove(4)}.";
            PrintToConsole(binaryTreeRemovingRoot, titleTreeRemovingRoot, textTreeRemovingRoot, ConsoleColor.Green);

            titleTreeRemovingRoot = "Removing the root of the binary tree.";

            textTreeRemovingRoot = $"The root = 2 has been removed => {binaryTreeRemovingRoot.Remove(2)}.";
            PrintToConsole(binaryTreeRemovingRoot, titleTreeRemovingRoot, textTreeRemovingRoot, ConsoleColor.DarkGreen);

            textTreeRemovingRoot = $"The root = 3 has been removed => {binaryTreeRemovingRoot.Remove(3)}.";
            PrintToConsole(binaryTreeRemovingRoot, titleTreeRemovingRoot, textTreeRemovingRoot, ConsoleColor.DarkGreen);

            textTreeRemovingRoot = $"The root = 1 has been removed => {binaryTreeRemovingRoot.Remove(1)}.";
            PrintToConsole(binaryTreeRemovingRoot, titleTreeRemovingRoot, textTreeRemovingRoot, ConsoleColor.DarkGreen);

            titleTreeRemovingRoot = "Removing from a tree without nodes.";

            textTreeRemovingRoot = $"The root = 0 has been removed => {binaryTreeRemovingRoot.Remove(0)}.";
            PrintToConsole(binaryTreeRemovingRoot, titleTreeRemovingRoot, textTreeRemovingRoot, ConsoleColor.DarkGreen);

            BinaryTree<int> binaryTreeRemovingNode = GetBinaryTree();

            string titleTreeRemovingNode = "Deleting a leaf of tree.";
            string textTreeRemovingNode = $"The node = 74 has been removed => {binaryTreeRemovingNode.Remove(74)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.Cyan);

            titleTreeRemovingNode = "The first case: Deleting a node that has one child item.";

            textTreeRemovingNode = $"The node = 100 has been removed => {binaryTreeRemovingNode.Remove(100)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.DarkCyan);

            titleTreeRemovingNode = "The second case: Deleting a node that has one child item.";

            textTreeRemovingNode = $"The node = 105 has been removed => {binaryTreeRemovingNode.Remove(105)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.DarkCyan);

            titleTreeRemovingNode = "The first case: Deleting a node that has two child item.";

            textTreeRemovingNode = $"The node = 82 has been removed => {binaryTreeRemovingNode.Remove(82)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.Magenta);

            titleTreeRemovingNode = "The second case: Deleting a node that has two child item.";

            textTreeRemovingNode = $"The node = 83 has been removed => {binaryTreeRemovingNode.Remove(83)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.DarkMagenta);

            titleTreeRemovingNode = "The third case: Deleting a node that has two child item.";

            textTreeRemovingNode = $"The node = 84 has been removed => {binaryTreeRemovingNode.Remove(84)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.Gray);

            titleTreeRemovingNode = "The third case: Deleting a node that has two child item.";

            textTreeRemovingNode = $"The node = 85 has been removed => {binaryTreeRemovingNode.Remove(85)}.";
            PrintToConsole(binaryTreeRemovingNode, titleTreeRemovingNode, textTreeRemovingNode, ConsoleColor.White);
        }

        public static void PrintToConsole<T>(BinaryTree<T> tree, string title, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(title);
            Console.WriteLine(new string('-', 80));

            Console.WriteLine(tree);

            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(text);
            Console.WriteLine(new string('#', 80));
            Console.WriteLine();

            Console.ResetColor();
        }

        public static BinaryTree<int> GetBinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(50);

            binaryTree.Add(45);
            binaryTree.Add(82);
            binaryTree.Add(20);
            binaryTree.Add(48);
            binaryTree.Add(60);
            binaryTree.Add(85);
            binaryTree.Add(74);
            binaryTree.Add(83);
            binaryTree.Add(84);
            binaryTree.Add(100);
            binaryTree.Add(105);
            binaryTree.Add(110);

            return binaryTree;
        }
    }
}