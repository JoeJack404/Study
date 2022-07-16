using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class MoreStonesTakenThanAllowedException : Exception
    {
        public MoreStonesTakenThanAllowedException(string message) : base(message)
        {

        }
    }
}
