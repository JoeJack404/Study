using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBook
    {
		private List<PhoneBookRecord> phoneBookRecords = new List<PhoneBookRecord>();
		public int Size { get; private set; } = 0;
		public void Add(PhoneBookRecord phoneBookRecord)                            //Метод добавления
		{
			phoneBookRecords.Add(phoneBookRecord);
			++Size;
		}

		public void PrintRecords()                                          //Метод печати
		{
			foreach (PhoneBookRecord record in phoneBookRecords)
			{
				Console.WriteLine("Имя: {0} Номер телефона: {1}", record.Name, record.Number);
			}
			if (phoneBookRecords.Count == 0)
				Console.WriteLine("Телефонная книга пуста");
		}

		public PhoneBookRecord FindRecord(int number)                     //Метод поиска
		{
			return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Number == number);
		}

		public PhoneBookRecord FindRecord(int number, string name)        //Метод поиска
		{
			return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Name == name & phoneBookRecords.Number == number);
		}

		public PhoneBookRecord FindRecord(string name)                   //Метод поиска
		{
			return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Name == name);
		}

		public void Clear()                      //Метод очистки
		{
			phoneBookRecords.Clear();
		}

		public void Remove(PhoneBookRecord record)      //удаление абонента
        {
			phoneBookRecords.Remove(record);
        }
	}
}
