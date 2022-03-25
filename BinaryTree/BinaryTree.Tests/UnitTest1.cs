using NUnit.Framework;

namespace BinaryTree.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Tree tree = new Tree();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            tree.AddKnot(12);
            tree.AddKnot(11);
            tree.AddKnot(5);
            tree.AddKnot(2);
            tree.AddKnot(3);
            tree.AddKnot(7);
            tree.AddKnot(9);
            tree.AddKnot(1);
            tree.AddKnot(13);
            tree.AddKnot(14);
            tree.AddKnot(15);
            tree.AddKnot(16);
            tree.AddKnot(17);
            tree.AddKnot(18);
            tree.AddKnot(40);
            tree.AddKnot(24);
            tree.AddKnot(23);
            tree.AddKnot(22);
            tree.AddKnot(21);
            tree.AddKnot(20);
            tree.AddKnot(19);
        }

        [Test]
        public void AddKnotTest()
        {
            Tree binaryTree = new Tree();
            binaryTree.AddKnot(10);
            Assert.AreEqual(10, binaryTree.root.Data);
            binaryTree.AddKnot(24);
            Assert.AreEqual(24, binaryTree.root.Right.Data);
            binaryTree.AddKnot(18);
            Assert.AreEqual(18, binaryTree.root.Right.Left.Data);
        }

        [Test]
        public void IsContainTest()
        {
            Tree tree = new Tree();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            Assert.IsTrue(tree.IsContain(10));
            Assert.IsTrue(tree.IsContain(4));
            Assert.IsFalse(tree.IsContain(12));
            Assert.IsTrue(tree.IsContain(8));
        }

        [Test]
        public void GetMinKnotTest()
        {
            Tree tree = new Tree();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            tree.AddKnot(12);
            Knot actualKnot = tree.GetMinKnot(tree.root);
            Assert.AreEqual(4, actualKnot.Data);
            Knot actualKnotTwo = tree.GetMinKnot(tree.root.Right);
            Assert.AreEqual(12, actualKnotTwo.Data);
        }
    }
}