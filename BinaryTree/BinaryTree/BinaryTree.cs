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

        public bool IsContain(int data)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return root.IsContain(root, data);
            }
        }
    }
}
