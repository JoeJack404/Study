﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class MoveStonesTakenThanLeftException : Exception
    {
        public MoveStonesTakenThanLeftException(string message) : base(message)
        {

        }
    }
}