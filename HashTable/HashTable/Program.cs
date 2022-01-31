using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.TryAdd("sdfr");
            hashtable.TryAdd("ddff");
            hashtable.TryAdd("dfhghhj");
            hashtable.TryAdd("asd");
            if (hashtable.IsContain("ddff"))
            {
                Console.WriteLine("Записб есть");
            }
            else
            {
                Console.WriteLine("Записи нет");
            }
            if (hashtable.IsContain("drtff"))
            {
                Console.WriteLine("Записб есть");
            }
            else
            {
                Console.WriteLine("Записи нет");
            }
            if (hashtable.RemoveContain("ddff"))
            {
                Console.WriteLine("Записб удалена");
            }
            else
            {
                Console.WriteLine("Запись не удалена");
            }
            if (hashtable.IsContain("ddff"))
            {
                Console.WriteLine("Записб есть");
            }
            else
            {
                Console.WriteLine("Записи нет");
            }
            int SumString(string value, int size)
            {
                size = 100;
                int hashResult = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    char symbol = value[i];
                    hashResult = Convert.ToInt32(symbol) + hashResult;
                }
                return hashResult % size;
            }
            hashtable.ChangeHashFunction(SumString);
        }
    }
}
