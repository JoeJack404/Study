using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree : Knot
    {
        private BinaryTree root;
        //private int data;
        //private BinaryTree left;
        //private BinaryTree right;

        public void AddKnot(int data)
        {
            if (root == null)
            {
                root = new BinaryTree();
                root.Data = data;
            }
            else if (root.Data > data)
            {
                if (root.Left == null)
                {
                    root.Left = new BinaryTree();
                    root.Left.Data = data;
                }
                else
                {
                    root.Left.AddKnot(data);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new BinaryTree();
                    root.Right.Data = data;
                }
                else
                {
                    root.Right.AddKnot(data);
                }
            }
        }

        public bool IsContain(int data)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.Data == data)
            {
                return true;
            }
            else if (root.Data > data)
            {
                return root.Left.IsContain(data);
            }
            else
            {
                return root.Right.IsContain(data);
            }
        }
    }
}
