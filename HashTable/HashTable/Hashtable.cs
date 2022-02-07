using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Hashtable
    {
        private List<string>[] table = new List<string>[100];
        public delegate int HashFunction(string value, int sizeTable);
        private static HashFunction currentHashFunction = DefaultHashFunction;
        private static int DefaultHashFunction(string value, int sizeTable)
        {
            double hashResult = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char symbol = value[i];
                hashResult = Math.Pow(2, i) * Convert.ToInt32(symbol) + hashResult;
            }
            double result = hashResult % sizeTable;
            return Convert.ToInt32(result);
        }

        //public bool TryAdd(string value)  // TryAdd
        //{
        //    int position = currentHashFunction(value, table.Length);
        //    if (table[position] == null)
        //    {
        //        table[position] = value;
        //        return true;
        //    }
        //    else if (table[position] == value)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        string[] newTable = new string[table.Length];
        //        Array.Copy(table, newTable, table.Length);
        //        Array.Clear(table, 0, table.Length);
        //        Array.Resize(ref table, table.Length * 3);
        //        foreach (string oldValue in newTable)
        //        {
        //            if (oldValue == null)
        //            {
        //            }
        //            else
        //            {
        //                int newPosition = currentHashFunction(oldValue, table.Length * 3);
        //                table[newPosition] = oldValue;
        //            }
        //        }
        //        TryAdd(value);
        //        return true;
        //    }
        //}

        //public bool IsContain(string value)   //IsContain
        //{
        //    int position = currentHashFunction(value, table.Length);
        //    return table[position] == value;
        //}

        //public bool RemoveContain(string value)
        //{
        //    int position = currentHashFunction(value, table.Length);
        //    if (table[position] == value)
        //    {
        //        Array.Clear(table, position, 1);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool TryAdd(string value)
        {
            int position = currentHashFunction(value, table.Length);
            if (table[position] == null)
            {
                table[position] = new List<string>();
                table[position].Add(value);
                return true;
            }
            else if (!table[position].Contains(value))
            {
                table[position].Add(value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsContain(string value)
        {
            int position = currentHashFunction(value, table.Length);
            if (table[position] == null)
            {
                return false;
            }
            else
            {
                return table[position].Contains(value);
            }
        }

        public bool TryRemove(string value)
        {
            int position = currentHashFunction(value, table.Length);
            if (table[position].Contains(value))
            {
                table[position].Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void ChangeHashFunction(HashFunction hashFunction)
        {
            currentHashFunction = hashFunction;
            List<string>[] newTable = new List<string>[table.Length];
            Array.Copy(table, newTable, table.Length);
            Array.Clear(table, 0, table.Length);
            foreach (List<string> field in newTable)
            {
                if (field != null)
                {
                    foreach (string value in field)
                    {
                        if (value != null)
                        {
                            TryAdd(value);
                        }
                    }
                }
            }
        }
    }
}
