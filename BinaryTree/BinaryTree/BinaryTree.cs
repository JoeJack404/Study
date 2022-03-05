﻿using System;
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
                AddKnot(root, data);
            }
        }

        private void AddKnot(Knot knot, int data)
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
                    AddKnot(knot.Left, data);
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
                    AddKnot(knot.Right, data);
                }
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
                return IsContain(root, data);
            }
        }

        private bool IsContain(Knot knot, int data)
        {
            if (knot == null)
            {
                return false;
            }
            else if (knot.Data == data)
            {
                return true;
            }
            else if (knot.Data > data)
            {
                return IsContain(knot.Left, data);
            }
            else
            {
                return IsContain(knot.Right, data);
            }
        }

        public bool RemoveKnot(int data)
        {
            if (!IsContain(root, data))
            {
                return false;
            }
            else if (root.Data == data)
            {
                Console.WriteLine("Удалить корневой элемент нельзя");
                return false;
            }
            else
            {
                Knot removeKnot = GetKnot(root, data);
                RemoveKnot(removeKnot);
                return true;
            }
        }

        private void RemoveKnot(Knot knot)
        {
            if (knot.Left == null & knot.Right == null)
            {
                knot = null;
            }
            else if (knot.Left == null ^ knot.Right == null)
            {
                if (knot.Left == null)
                {
                    knot = knot.Right;
                }
                else
                {
                    knot = knot.Left;
                }
            }
            else
            {
                Knot newKnot = GetMinKnot(knot.Right);
                Knot parentMinKnot = GetParentKnot(knot.Right, newKnot);
                parentMinKnot.Left = null;
                knot.Data = newKnot.Data;
            }
        }

        private Knot GetMinKnot(Knot knot)
        {
            if (knot.Left == null)
            {
                return knot;
            }
            else
            {
                return GetMinKnot(knot.Left);
            }
        }

        private Knot GetKnot(Knot knot, int data)
        {
            if (knot.Data == data)
            {
                return knot;
            }
            else if (knot.Data > data)
            {
                return GetKnot(knot.Left, data);
            }
            else
            {
                return GetKnot(knot.Right, data);
            }
        }

        private Knot GetParentKnot(Knot currentKnot, Knot knot)
        {
            if (currentKnot.Left == knot)
            {
                return currentKnot;
            }
            else
            {
                return GetParentKnot(currentKnot.Left, knot);
            }
        }
    }
}
