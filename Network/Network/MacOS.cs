using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class MacOS : IOperationSystem
    {
        double IOperationSystem.ChanceOfInfection 
        { 
            get { return 0.06; } 
        }
    }
}
