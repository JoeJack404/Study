﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    class GameOverException : Exception
    {
        public GameOverException(string message) : base(message)
        {

        }
    }
}