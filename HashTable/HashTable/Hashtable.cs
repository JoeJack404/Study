using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Hashtable
    {
        private string[] Table = new string[100];
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
            int position = HashFunction(value, Table.Length);
            if (Table[position] == null)
            {
                Table[position] = value;
                return true;
            }
            else if (Table[position] == value)
            {
                return false;
            }
            else
            {
                string[] newTable = new string[Table.Length];
                Array.Copy(Table, 0, newTable, 0, Table.Length);
                Array.Clear(Table, 0, Table.Length);
                Array.Resize(ref Table, Table.Length + 100);
                foreach (string oldValue in newTable)
                {
                    int newPosition = HashFunction(oldValue, Table.Length + 100);
                    Table[newPosition] = oldValue;
                }
                Add(value);
                return true;
            }
        }
    }
}
