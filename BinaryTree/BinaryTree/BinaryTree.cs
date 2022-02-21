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
                Knot knot = new Knot();
                knot.Data = data;
                root = knot;
            }
            else if (root.Data > data)
            {
                if (root.Left == null)
                {
                    Knot knot = new Knot();
                    knot.Data = data;
                    root.Left = knot;
                }
                else
                {
                    root = root.Left;
                    AddKnot(data);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    Knot knot = new Knot();
                    knot.Data = data;
                    root.Right = knot;
                }
                else
                {
                    root = root.Right;
                    AddKnot(data);
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
                root = root.Left;
                return IsContain(data);
            }
            else
            {
                root = root.Right;
                return IsContain(data);
            }
        }
    }
}
