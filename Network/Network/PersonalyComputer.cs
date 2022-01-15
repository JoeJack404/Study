using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class PersonalyComputer
    {
        public List<int> Links = new List<int>();
        public IOperationSystem OS { get; set; }
        public bool IsInfected { get; set; }

        public PersonalyComputer(IOperationSystem oS, bool IsInfected = false)
        {
            OS = oS;
            this.IsInfected = IsInfected;
        }
        public int IPAddress { get; set; }
    }
}
