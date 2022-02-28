using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Knot
    {
        public int Data { get; set; }
        public Knot Left { get; set; }
        public Knot Right { get; set; }

        public void Add(Knot knot, int data)
        {
            if (knot.Data > data)
            {
                if (knot.Left == null)
                {
                    knot.Left = new Knot();
                    knot.Left.Data = data;
                }
                else
                {
                    Add(knot.Left, data);
                }
            }
            else
            {
                if (knot.Right == null)
                {
                    knot.Right = new Knot();
                    knot.Right.Data = data;
                }
                else
                {
                    Add(knot.Right, data);
                }
            }
        }
    }
}
