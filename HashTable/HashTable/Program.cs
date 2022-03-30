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
            hashtable.TryAdd("aaa");
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
            if (hashtable.TryRemove("ddff"))
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
                return 1;
            }
            hashtable.ChangeHashFunction(SumString);
            hashtable.TryAdd("aaa");
        }
    }
}
