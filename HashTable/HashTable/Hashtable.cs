using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Hashtable
    {
        private string[] table = new string[100];
        private int HashFunction(string value, int sizeTable)
        {
            double hashResult = 0;
            for (int i = 0; i < value.Length; i ++)
            {
                char symbol = value[i];
                hashResult = Math.Pow(2, i) * Convert.ToInt32(symbol) + hashResult;
            }
            double result = hashResult % sizeTable;
            return Convert.ToInt32(result);
        }

        public bool Add(string value)
        {
            int position = HashFunction(value, table.Length);
            if (table[position] == null)
            {
                table[position] = value;
                return true;
            }
            else if (table[position] == value)
            {
                return false;
            }
            else
            {
                string[] newTable = new string[table.Length];
                Array.Copy(table, newTable, table.Length);
                Array.Clear(table, 0, table.Length);
                Array.Resize(ref table, table.Length + 100);
                foreach (string oldValue in newTable)
                {
                    if (oldValue == null)
                    {
                    }
                    else
                    {
                        int newPosition = HashFunction(oldValue, table.Length + 100);
                        table[newPosition] = oldValue;
                    }
                }
                Add(value);
                return true;
            }
        }

        public bool CheckRecord(string value)
        {
            int position = HashFunction(value, table.Length);
            if (table[position] == null)
            {
                return false;
            }
            else if (table[position] == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveRecord(string value)
        {
            int position = HashFunction(value, table.Length);
            if (table[position] == null)
            {
                return false;
            }
            else if (table[position] == value)
            {
                Array.Clear(table, position, 1);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
