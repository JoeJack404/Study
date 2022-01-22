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

        private int HashFunction(string value, int sizeTable = 100)
        {
            return 1;
        }

        public bool Add(string value)
        {
            int position = HashFunction(value);
            if (Table[position] == null)
            {
                Table[position] = value;
                return true;
            }
            else
            {
                //Array.Resize(ref Table, Table.Length + 100);
                //foreach (string oldValue in Table)
                //{
                //    int newPosition = HashFunction(oldValue, Table.Length + 100);
                //    Table[newPosition] = oldValue;
                //}
                //Add(value);
                return false;
            }
        }
    }
}
