using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("sdfr");
            hashtable.Add("ddff");
            hashtable.Add("dfhghhj");
            hashtable.Add("asd");
            if (hashtable.CheckRecord("ddff"))
            {
                Console.WriteLine("Записб есть");
            }
            else
            {
                Console.WriteLine("Записи нет");
            }
            if (hashtable.CheckRecord("drtff"))
            {
                Console.WriteLine("Записб есть");
            }
            else
            {
                Console.WriteLine("Записи нет");
            }
            if (hashtable.RemoveRecord("ddff"))
            {
                Console.WriteLine("Записб удалена");
            }
            else
            {
                Console.WriteLine("Запись не удалена");
            }
            if (hashtable.CheckRecord("ddff"))
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
