using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Knot<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Knot<T> Left { get; set; }
        public Knot<T> Right { get; set; }
    }
}
