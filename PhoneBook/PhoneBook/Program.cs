using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            ConsoleOutput.WriteGreeting();
            int userchoice = -1;
            while (userchoice != 0)
            {
                ConsoleOutput.WriteChoice();
                userchoice = Convert.ToInt32(Console.ReadLine());
                switch (userchoice)
                {
                    case 1:
                        {
                            phoneBook.PrintRecords();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите имя абонента");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите номер абонента");
                            int number = Convert.ToInt32(Console.ReadLine());
                            PhoneBookRecord newRecord = new PhoneBookRecord(name, number);
                            phoneBook.Add(newRecord);
                            Console.WriteLine("Абонент имя: {0} номер: {1} успешно добавлен!", name, number);
                            break;
                        }
                    case 3:
                        {
                            phoneBook.Clear();
                            Console.WriteLine("Телефонная книга успешно очищена");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите имя или номер абонента");
                            int number;
                            string name;
                            string nameOrNumber = Console.ReadLine();
                            if (int.TryParse(nameOrNumber, out number))
                            {
                                number = Convert.ToInt32(nameOrNumber);
                                PhoneBookRecord recordname = phoneBook.FindRecord(number);
                                if (recordname == null)
                                {
                                    Console.WriteLine("Данный номер телефона, к сожалению, не найден");
                                }
                                else
                                {
                                    Console.WriteLine("Абонент {0} номер {1} успешно найден!", recordname.Name, recordname.Number);
                                }
                            }
                            else
                            {
                                name = nameOrNumber;
                                PhoneBookRecord recordnumber = phoneBook.FindRecord(name);
                                if (recordnumber == null)
                                {
                                    Console.WriteLine("Данный абонент, к сожалению, не найден");
                                }
                                else
                                {
                                    Console.WriteLine("Абонент {0} номер {1} успешно найден!", recordnumber.Name, recordnumber.Number);
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Введите имя абонента");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите номер абонента");
                            int number = Convert.ToInt32(Console.ReadLine());
                            PhoneBookRecord record = phoneBook.FindRecord(number, name);
                            if (record == null)
                            {
                                Console.WriteLine("Данная запись не найдена");
                                break;
                            }
                            Console.WriteLine("Абонент {0} номер {1} успешно найден", record.Name, record.Number);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Введите имя или номер абонент");
                            int number;
                            string name;
                            string numberOrName = Console.ReadLine();
                            if (int.TryParse(numberOrName, out number))
                            {
                                number = Convert.ToInt32(numberOrName);
                                PhoneBookRecord recordnameremove = phoneBook.FindRecord(number);
                                if (recordnameremove == null)
                                {
                                    Console.WriteLine("Данная запись не найдена");
                                }
                                else
                                {
                                    phoneBook.Remove(recordnameremove);
                                    Console.WriteLine("Абонент имя {0} номер {1} успешно удален!", recordnameremove.Name, recordnameremove.Number);
                                }
                            }
                            else
                            {
                                name = numberOrName;
                                PhoneBookRecord recordnumberremove = phoneBook.FindRecord(name);
                                if (recordnumberremove == null)
                                {
                                    Console.WriteLine("Данная запись не найдена");
                                }
                                else
                                {
                                    phoneBook.Remove(recordnumberremove);
                                    Console.WriteLine("Абонент имя {0} номер {1} успешно удален!", recordnumberremove.Name, recordnumberremove.Number);
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            phoneBook.WriteFile();
                            Console.WriteLine("Телефоная книга успешно сохранена");
                            break;
                        }
                    case 8:
                        {
                            phoneBook.Clear();
                            phoneBook.LoadFile();
                            break;
                        }
                    case 0:
                        break;
                    default:
                        {
                            Console.WriteLine("Введённое Вами значение не соответсвует заявленым");
                            break;
                        }
                }
            }
            ConsoleOutput.WriteFarewell();
        }
    }
}
