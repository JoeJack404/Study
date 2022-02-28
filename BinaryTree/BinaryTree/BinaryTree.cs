using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        private Knot root;
        //private int data;
        //private BinaryTree left;
        //private BinaryTree right;

        public void AddKnot(int data)
        {
            if (root == null)
            {
                root = new Knot();
                root.Data = data;
            }
            else
            {
                root.Add(root, data);
            }
        }

        //public bool IsContain(int data)
        //{
        //    if (root == null)
        //    {
        //        return false;
        //    }
        //    else if (root.Data == data)
        //    {
        //        return true;
        //    }
        //    else if (root.Data > data)
        //    {
        //        return root.Left.IsContain(data);
        //    }
        //    else
        //    {
        //        return root.Right.IsContain(data);
        //    }
        //}
    }
}
