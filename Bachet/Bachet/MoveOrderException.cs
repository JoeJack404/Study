using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class MoveOrderException : Exception
    {
        public MoveOrderException(string message) : base(message)
        {

        }
    }
}
