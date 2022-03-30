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

        /// <summary>
        /// Добавление строчки.
        /// </summary>
        /// <param name="value">Строчка.</param>
        /// <returns>True - запись успешно добавлена, false - такая запись уже есть.</returns>
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

        /// <summary>
        /// Проверяет есть ли такая строчка.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True - строчка есть, false - данной записи нет.</returns>
        public bool IsContain(string value)
        {
            int position = currentHashFunction(value, table.Length);
            return table[position] == null ? false : table[position].Contains(value);
        }

        /// <summary>
        /// Удаляет запись.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True - запись удалена, false - такой записи нет.</returns>
        public bool TryRemove(string value)
        {
            int position = currentHashFunction(value, table.Length);
            if (table[position] != null)
            {
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
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Меняет хэш-функцию.
        /// </summary>
        /// <param name="hashFunction">Хэш-фукнция, принимает строчку и размез таблицы, возвращет число.</param>
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
                        TryAdd(value);
                    }
                }
            }
        }
    }
}
