using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class CreateBotException : Exception
    {
        public CreateBotException(string message) : base(message)
        {

        }
    }
}
