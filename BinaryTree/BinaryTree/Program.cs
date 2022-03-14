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
            binaryTree.AddKnot(13);
            binaryTree.AddKnot(14);
            binaryTree.AddKnot(15);
            binaryTree.AddKnot(16);
            binaryTree.AddKnot(17);
            binaryTree.AddKnot(18);
            binaryTree.AddKnot(40);
            binaryTree.AddKnot(24);
            binaryTree.AddKnot(23);
            binaryTree.AddKnot(22);
            binaryTree.AddKnot(21);
            binaryTree.AddKnot(20);
            binaryTree.AddKnot(19);
            binaryTree.PrintTree();
        }
    }
}
