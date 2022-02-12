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

        public void TryAddKnot(int data)
        {
            if (root == null)
            {
                root.Data = data;
                root.Left = null;
                root.Right = null;
            }
            else if (root.Data > data)
            {
                root = root.Left;
                TryAddKnot(data);
            }
            else
            {
                root = root.Right;
                TryAddKnot(data);
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
                root = root.Left;
                IsContain(data);
                return true;
            }
            else
            {
                root = root.Right;
                IsContain(data);
                return true;
            }
        }
    }
}
