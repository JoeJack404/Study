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
        /// <summary>
        /// Добавляет новый узел.
        /// </summary>
        /// <param name="data">Значение, которое добавится</param>
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
        /// <summary>
        /// Проверяет есть ли такой узел.
        /// </summary>
        /// <param name="data">Значение для проверки</param>
        /// <returns></returns>
        public bool IsContain(int data)
        {
            return root == null ? false : IsContain(root, data);
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
        /// <summary>
        /// Удаляет узел.
        /// </summary>
        /// <param name="data">Значение в узле</param>
        public void RemoveKnot(int data)
        {
            if (!IsContain(root, data))
            {
                Console.WriteLine("Такого узла нет");
            }
            else
            {
                Knot removeKnot = GetKnotByValue(root, data);
                RemoveKnot(removeKnot);
            }
        }

        private void RemoveKnot(Knot knot)
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
                        Knot newKnot = GetMinKnot(root.Right);
                        Knot parentMinKnot = GetParentKnot(root.Right, newKnot);
                        parentMinKnot.Left = null;
                        root.Data = newKnot.Data;
                    }
                }
            }
            else
            {
                Knot parentKnot = GetParentKnot(root, knot);
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
                        Knot newKnot = GetMinKnot(knot.Right);
                        Knot parentMinKnot = GetParentKnot(knot.Right, newKnot);
                        parentMinKnot.Left = null;
                        knot.Data = newKnot.Data;
                    }
                }
            }
        }
        /// <summary>
        /// Возвращет  самого левого наследника
        /// </summary>
        /// <param name="knot">Узел</param>
        /// <returns>Самый левый наследник</returns>
        private Knot GetMinKnot(Knot knot)
        {
            return knot.Left == null ? knot : GetMinKnot(knot.Left);
        }
        /// <summary>
        /// Находит узел по значению
        /// </summary>
        /// <param name="knot">Узел, с которого начинается поиск</param>
        /// <param name="data">Значение в узле</param>
        /// <returns>Узел с заданным значение</returns>
        private Knot GetKnotByValue(Knot knot, int data)
        {
            if (knot.Data == data)
            {
                return knot;
            }
            else if (knot.Data > data)
            {
                return GetKnotByValue(knot.Left, data);
            }
            else
            {
                return GetKnotByValue(knot.Right, data);
            }
        }
        /// <summary>
        /// Возвращет "родителя" узла
        /// </summary>
        /// <param name="currentKnot">Узел, с которого начинается поиск</param>
        /// <param name="knot">Узел, для которого ищется родитель</param>
        /// <returns>"Родитель"</returns>
        private Knot GetParentKnot(Knot currentKnot, Knot knot)
        {
            if (currentKnot.Left == knot ^ currentKnot.Right == knot)
            {
                return currentKnot;
            }
            else if (currentKnot.Data > knot.Data)
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
        /// Печатает содержимое дерева по возрастанию.
        /// </summary>
        public void PrintTree()
        {
            Knot minKnot = GetMinKnot(root);
            PrintTree(minKnot);
        }

        private void PrintTree(Knot knot)
        {
            Knot returnKnot = PrintLeftKnot(knot);
            if (returnKnot != null)
            {
                PrintTree(returnKnot);
            }
        }
        /// <summary>
        /// Печаетает левых наследников узла.
        /// </summary>
        /// <param name="knot"></param>
        /// <returns></returns>
        private Knot PrintLeftKnot(Knot knot)
        {
            Console.WriteLine(knot.Data);
            if (knot.Right == null)
            {
                return GetParentKnot(root, knot);
            }
            else
            {
                Knot returnKnot = PrintRightKnot(knot.Right);
                //if (returnKnot == null)
                //{
                //    return GetParentKnot(root, knot);
                //}
                //else
                //{
                //    PrintLeftKnot(GetParentKnot(root, returnKnot));
                //    return GetParentKnot(root, knot);
                }
            }
        }
        /// <summary>
        /// Печатает правых наследников узла.
        /// </summary>
        /// <param name="knot"></param>
        private Knot PrintRightKnot(Knot knot)
        {
            if (knot.Left != null & knot.Right == null)
            {
                Knot minKnot = GetMinKnot(knot);
                Knot returnKnot = PrintLeftKnot(minKnot);
                Console.WriteLine(knot.Data);
                return returnKnot;
            }
            else if (knot.Left != null & knot.Right != null)
            {
                Knot minKnot = GetMinKnot(knot);
                PrintLeftKnot(minKnot);
                Console.WriteLine(knot.Data);
                PrintRightKnot(knot.Right);
                return null;
            }
            else if (knot.Right != null)
            {
                Console.WriteLine(knot.Data);
                PrintRightKnot(knot.Right);
                return null;
            }
            else
            {
                Console.WriteLine(knot.Data);
                return null;
            }
        }
    }
}
