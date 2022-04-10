using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    static class ConsoleOutput
    {
		public static void WriteGreeting()
		{
			Console.WriteLine("Рады приветствовать Вас в нашей телефонной книге!");
		}

		public static void WriteFarewell()
        {
			Console.WriteLine("До свидания!");
        }

		public static void WriteChoice()
		{
			Console.WriteLine();
			Console.WriteLine("Если Вы хотите посмотреть всех абонентов в телефонной книге, нажмите 1");
			Console.WriteLine("Если Вы хотите добавить нового абонента, нажмите 2");
			Console.WriteLine("Если Вы хотите очистить телефонную книгу, нажмите 3");
			Console.WriteLine("Если Вы хотите найти абонента по номеру телефона или имени, нажмите 4");
			Console.WriteLine("Если Вы хотите найти конкретного абонента, нажмите 5");
			Console.WriteLine("Если Вы хотите удалить абонента, нажмите 6");
			Console.WriteLine("Если Вы хотите записать телефонную книгу в файл, нажмите 7");
			Console.WriteLine("Если Вы хотите загрузить телефонную книгу из файла, нажмите 8");
			Console.WriteLine("Если Вы хотите выйти из телефонной книги, нажмите 0");
		}
	}
}
