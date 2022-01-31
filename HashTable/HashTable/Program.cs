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
        }
    }
}
