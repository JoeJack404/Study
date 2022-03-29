using NUnit.Framework;

namespace BinaryTree.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddKnotTest()
        {
            Tree<int> binaryTree = new Tree<int>();
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
            Tree<int> tree = new Tree<int>();
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
            Tree<int> tree = new Tree<int>();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            tree.AddKnot(12);
            Knot<int> actualKnot = tree.GetMinKnot(tree.root);
            Assert.AreEqual(4, actualKnot.Data);
            Knot<int> actualKnotTwo = tree.GetMinKnot(tree.root.Right);
            Assert.AreEqual(12, actualKnotTwo.Data);
        }

        [Test]
        public void GetKnotByValueTest()
        {
            Tree<int> tree = new Tree<int>();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            tree.AddKnot(12);
            Knot<int> actualKnot = tree.GetKnotByValue(tree.root, 8);
            Assert.AreEqual(tree.root.Left.Right, actualKnot);
            Knot<int> actualKnotTwo = tree.GetKnotByValue(tree.root, 12);
            Assert.AreEqual(tree.root.Right, actualKnotTwo);
            Knot<int> nullKnot = tree.GetKnotByValue(tree.root, 9);
            Assert.AreEqual(null, nullKnot);
        }

        [Test]
        public void GetParentKnotTest()
        {
            Tree<int> tree = new Tree<int>();
            tree.AddKnot(10);
            tree.AddKnot(6);
            tree.AddKnot(8);
            tree.AddKnot(4);
            tree.AddKnot(12);
            Knot<int> actualKnot = tree.GetParentKnot(tree.root, tree.root.Left.Left);
            Assert.AreEqual(tree.root.Left, actualKnot);
            Knot<int> actualKnotTwo = tree.GetParentKnot(tree.root, tree.root.Right);
            Assert.AreEqual(tree.root, actualKnotTwo);
            Knot<int> nullKnot = tree.GetParentKnot(tree.root, tree.root);
            Assert.AreEqual(null, nullKnot);
        }
        
        [Test]
        public void PrintAscendingTest()
        {
            Tree<int> tree = new Tree<int>();
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
            string actualKnotData = tree.PrintAscending();
            string testStringData = "12345678910111213141516171819202122232440";
            Assert.AreEqual(actualKnotData, testStringData);
            tree.RemoveKnot(22);
            string actualKnotDataTwo = tree.PrintAscending();
            string testStringDataTwo = "123456789101112131415161718192021232440";
            Assert.AreEqual(actualKnotDataTwo, testStringDataTwo);
        }

        [Test]
        public void PrintDescendingTest()
        {
            Tree<int> tree = new Tree<int>();
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
            string actualKnotData = tree.PrintDescending();
            string testStringData = "40242322212019181716151413121110987654321";
            Assert.AreEqual(actualKnotData, testStringData);
            tree.RemoveKnot(22);
            string actualKnotDataTwo = tree.PrintDescending();
            string testStringDataTwo = "402423212019181716151413121110987654321";
            Assert.AreEqual(actualKnotDataTwo, testStringDataTwo);
        }
    }
}