using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    class PhoneBook
    {
        private List<PhoneBookRecord> phoneBookRecords = new List<PhoneBookRecord>();
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Добавлениенового абонента.
        /// </summary>
        /// <param name="phoneBookRecord"></param>
        public void Add(PhoneBookRecord phoneBookRecord)
        {
            phoneBookRecords.Add(phoneBookRecord);
            ++Size;
        }

        /// <summary>
        /// Печать содержимого.
        /// </summary>
        public void PrintRecords()
        {
            foreach (PhoneBookRecord record in phoneBookRecords)
            {
                Console.WriteLine("Имя: {0} Номер телефона: {1}", record.Name, record.Number);
            }
            if (phoneBookRecords.Count == 0)
                Console.WriteLine("Телефонная книга пуста");
        }

        /// <summary>
        /// Поиск абонента.
        /// </summary>
        /// <param name="number">Номер абонента</param>
        /// <returns></returns>
        public PhoneBookRecord FindRecord(int number)
        {
            return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Number == number);
        }

        /// <summary>
        /// Поиск конкретного абонента.
        /// </summary>
        /// <param name="number">Номер.</param>
        /// <param name="name">Имя.</param>
        /// <returns></returns>
        public PhoneBookRecord FindRecord(int number, string name)
        {
            return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Name == name & phoneBookRecords.Number == number);
        }

        /// <summary>
        /// Поиск абонента.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <returns></returns>
        public PhoneBookRecord FindRecord(string name)
        {
            return phoneBookRecords.Find(phoneBookRecords => phoneBookRecords.Name == name);
        }

        /// <summary>
        /// Очистка телефонной книги.
        /// </summary>
        public void Clear()
        {
            phoneBookRecords.Clear();
        }

        /// <summary>
        /// Удаление абонента.
        /// </summary>
        /// <param name="record"></param>
        public void Remove(PhoneBookRecord record)
        {
            phoneBookRecords.Remove(record);
        }

        /// <summary>
        /// Запись телефонной книги в файл.
        /// </summary>
        public void WriteFile()
        {
            string path = @"D:\Study\PhoneBook\Phonebook.txt";
            using (FileStream phoneBookFile = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (PhoneBookRecord recordPhoneBook in phoneBookRecords)
                {
                    byte[] recordNameByte = Encoding.Default.GetBytes(recordPhoneBook.Name);
                    string stringNumber = recordPhoneBook.Number.ToString();
                    byte[] recordNumberByte = Encoding.Default.GetBytes(stringNumber);
                    byte[] breakLine = Encoding.Default.GetBytes("\n");
                    byte[] space = Encoding.Default.GetBytes(" ");
                    phoneBookFile.Write(recordNameByte);
                    phoneBookFile.Write(space);
                    phoneBookFile.Write(recordNumberByte);
                    phoneBookFile.Write(breakLine);
                }
            }
        }

        /// <summary>
        /// Загружает телефонную книгу из файла.
        /// </summary>
        public async void LoadFile()
        {
            string path = @"D:\Study\PhoneBook\Phonebook.txt";
            using (StreamReader phoneBookFile = new StreamReader(path))
            {
                string? line;
                while ((line = await phoneBookFile.ReadLineAsync()) != null)
                {
                    string[] nameNumber = line.Split(' ');
                    PhoneBookRecord phoneBook = new PhoneBookRecord(nameNumber[0], Convert.ToInt32(nameNumber[1]));
                    Add(phoneBook);
                }
            }
        }
    }
}
