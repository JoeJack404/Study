using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBookRecord
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public PhoneBookRecord(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
