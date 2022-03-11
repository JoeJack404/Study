using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.AddKnot(10);
            binaryTree.AddKnot(6);
            binaryTree.AddKnot(8);
            binaryTree.AddKnot(4);
            binaryTree.AddKnot(12);
            binaryTree.AddKnot(11);
            binaryTree.AddKnot(5);
            binaryTree.IsContain(5);
            binaryTree.AddKnot(2);
            binaryTree.AddKnot(3);
            binaryTree.AddKnot(7);
            binaryTree.AddKnot(9);
            binaryTree.AddKnot(1);
            binaryTree.RemoveKnot(6);
            binaryTree.RemoveKnot(1);
            binaryTree.RemoveKnot(10);
        }
    }
}
