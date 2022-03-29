using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public Knot<T> root;

        /// <summary>
        /// Добавляет новый узел.
        /// </summary>
        /// <param name="data">Новое значение.</param>
        public void AddKnot(T data)
        {
            if (root == null)
            {
                root = new Knot<T>();
                root.Data = data;
            }
            else
            {
                AddKnot(root, data);
            }
        }

        public void AddKnot(Knot<T> knot, T data)
        {
            if (knot.Data.CompareTo(data) > 0)
            {
                if (knot.Left == null)
                {
                    knot.Left = new Knot<T>();
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
                    knot.Right = new Knot<T>();
                    knot.Right.Data = data;
                }
                else
                {
                    AddKnot(knot.Right, data);
                }
            }
        }

        /// <summary>
        /// Проверяет есть ли такой узел.
        /// </summary>
        /// <param name="data">Значение в узле.</param>
        /// <returns></returns>
        public bool IsContain(T data)
        {
            return root == null ? false : IsContain(root, data);
        }

        public bool IsContain(Knot<T> knot, T data)
        {
            if (knot == null)
            {
                return false;
            }
            else if (knot.Data.CompareTo(data) == 0)
            {
                return true;
            }
            else if (knot.Data.CompareTo(data) > 0)
            {
                return IsContain(knot.Left, data);
            }
            else
            {
                return IsContain(knot.Right, data);
            }
        }

        /// <summary>
        /// Удаляет узел.
        /// </summary>
        /// <param name="data">Значение в узле</param>
        public void RemoveKnot(T data)
        {
            if (!IsContain(root, data))
            {
                Console.WriteLine("Такого узла нет");
            }
            else
            {
                Knot<T> removeKnot = GetKnotByValue(root, data);
                RemoveKnot(removeKnot);
            }
        }

        public void RemoveKnot(Knot<T> knot)
        {
            if (root == knot)
            {
                if (root.Left == null & root.Right == null)
                {
                    root = null;
                    Console.WriteLine("Дерево пусто");
                }
                else if (root.Left == null ^ root.Right == null)
                {
                    if (root.Left == null)
                    {
                        root = root.Right;
                    }
                    else
                    {
                        root = root.Left;
                    }
                }
                else
                {
                    if (root.Right.Left == null)
                    {
                        root.Right.Left = root.Left;
                        root = root.Right;
                    }
                    else
                    {
                        Knot<T> newKnot = GetMinKnot(root.Right);
                        Knot<T> parentMinKnot = GetParentKnot(root.Right, newKnot);
                        parentMinKnot.Left = null;
                        root.Data = newKnot.Data;
                    }
                }
            }
            else
            {
                Knot<T> parentKnot = GetParentKnot(root, knot);
                if (knot.Left == null & knot.Right == null)
                {
                    if (parentKnot.Left == knot)
                    {
                        parentKnot.Left = null;
                    }
                    else
                    {
                        parentKnot.Right = null;
                    }
                }
                else if (knot.Left == null ^ knot.Right == null)
                {
                    if (knot.Left == null)
                    {
                        if (parentKnot.Left == knot)
                        {
                            parentKnot.Left = knot.Right;
                        }
                        else
                        {
                            parentKnot.Right = knot.Right;
                        }
                    }
                    else
                    {
                        if (parentKnot.Left == knot)
                        {
                            parentKnot.Left = knot.Left;
                        }
                        else
                        {
                            parentKnot.Right = knot.Left;
                        }
                    }
                }
                else
                {
                    if (knot.Right.Left == null)
                    {
                        if (parentKnot.Left == knot)
                        {
                            knot.Right.Left = knot.Left;
                            parentKnot.Left = knot.Right;
                        }
                        else
                        {
                            knot.Right.Left = knot.Left;
                            parentKnot.Right = knot.Right;
                        }
                    }
                    else
                    {
                        Knot<T> newKnot = GetMinKnot(knot.Right);
                        Knot<T> parentMinKnot = GetParentKnot(knot.Right, newKnot);
                        parentMinKnot.Left = null;
                        knot.Data = newKnot.Data;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращет  самого левого наследника.
        /// </summary>
        /// <param name="knot">Узел</param>
        /// <returns>Узел.</returns>
        public Knot<T> GetMinKnot(Knot<T> knot)
        {
            return knot.Left == null ? knot : GetMinKnot(knot.Left);
        }

        /// <summary>
        /// Находит узел по значению
        /// </summary>
        /// <param name="knot">Узел, с которого начинается поиск.</param>
        /// <param name="data">Значение в узле.</param>
        /// <returns>Узел.</returns>
        public Knot<T> GetKnotByValue(Knot<T> knot, T data)
        {
            if (IsContain(data))
            {
                if (knot.Data.CompareTo(data) == 0)
                {
                    return knot;
                }
                else if (knot.Data.CompareTo(data) > 0)
                {
                    return GetKnotByValue(knot.Left, data);
                }
                else
                {
                    return GetKnotByValue(knot.Right, data);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Возвращет "родителя" узла.
        /// </summary>
        /// <param name="currentKnot">Узел, с которого начинается поиск</param>
        /// <param name="knot">Узел</param>
        /// <returns>"Родитель"</returns>
        public Knot<T> GetParentKnot(Knot<T> currentKnot, Knot<T> knot)
        {
            if (currentKnot.Left == knot ^ currentKnot.Right == knot)
            {
                return currentKnot;
            }
            else if (currentKnot.Data.CompareTo(knot.Data) > 0)
            {
                return GetParentKnot(currentKnot.Left, knot);
            }
            else if (currentKnot == knot)
            {
                return null;
            }
            else
            {
                return GetParentKnot(currentKnot.Right, knot);
            }
        }

        /// <summary>
        /// Печать содержимого дерева по возрастанию.
        /// </summary>
        public string PrintAscending()
        {
            List<T> knots = new List<T>();
            PrintAscending(root, knots);
            string forTestString = null;
            foreach (T knotData in knots)
            {
                Console.Write(knotData + " ");
                forTestString = forTestString + Convert.ToString(knotData);
            }
            Console.WriteLine();
            return forTestString;
        }

        public void PrintAscending(Knot<T> knot, List<T> knots)
        {
            if (knot.Left != null)
            {
                PrintAscending(knot.Left, knots);
            }
            knots.Add(knot.Data);
            if (knot.Right != null)
            {
                PrintAscending(knot.Right, knots);
            }
        }

        /// <summary>
        /// Печать содержимого дерева по убыванию.
        /// </summary>
        public string PrintDescending()
        {
            List<T> knots = new List<T>();
            PrintDescending(root, knots);
            string forTestString = null;
            foreach (T knotData in knots)
            {
                Console.Write(knotData + " ");
                forTestString = forTestString + Convert.ToString(knotData);
            }
            Console.WriteLine();
            return forTestString;
        }

        public void PrintDescending(Knot<T> knot, List<T> knots)
        {
            if (knot.Right != null)
            {
                PrintDescending(knot.Right, knots);
            }
            knots.Add(knot.Data);
            if (knot.Left != null)
            {
                PrintDescending(knot.Left, knots);
            }
        }
    }
}
