using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class TableField
    {
        private List<string> tableField = new List<string>();

        public List<string> tF { get { return tableField} set { tableField.Add(value); } }
    }
}
