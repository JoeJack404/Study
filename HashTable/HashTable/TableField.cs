using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class TableField
    {
        private List<string> tableFlied = new List<string>();

        public List<string> tF { get { return tableFlied} set { tableFlied.Add(value); } }
    }
}
