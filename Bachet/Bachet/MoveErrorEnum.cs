﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachet
{
    public enum MoveErrorEnum
    {
        None,
        GameOverError,
        MoreStonesTakenThanLeft,
        MoreStonesTakenThanAllowed,
        MoveOrderError
    }
}
