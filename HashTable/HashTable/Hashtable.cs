using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Hashtable
    {
        private TableField[] table = new TableField[100];
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
            if ()

        }
        
        public void ChangeHashFunction(HashFunction hashFunction)
        {
            currentHashFunction = hashFunction;
            TableField[] newTable = new TableField[table.Length];
            Array.Copy(table, newTable, table.Length);
            Array.Clear(table, 0, table.Length);
            foreach (TableField oldField in newTable)
            {
                if (oldField != null)
                {
                    foreach (string oldValue in oldField)
                    TryAdd(oldValue);
                }
            }
        }
    }
}
