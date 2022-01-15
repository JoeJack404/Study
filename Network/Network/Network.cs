using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class Network
    {
        private List<PersonalyComputer> pC = new List<PersonalyComputer>();
        public void Add(PersonalyComputer personalyComputer, int iPAddress)
        {
            if (pC.Exists(x => x.IPAddress == iPAddress))
            {
                Console.WriteLine("Данный IP-адрес занят");
            }
            else
            {
                personalyComputer.IPAddress = iPAddress;
                pC.Add(personalyComputer);
            }
        }

        public int NumberOfInfection()
        { 
            return pC.FindAll(x => x.IsInfected).Count;
        }

        public bool TryAddLink(int iPAddress1, int iPAddress2)
        {
            if (pC.Exists(x => x.IPAddress == iPAddress1) && pC.Exists(x => x.IPAddress == iPAddress2))
            {
                PersonalyComputer pc1 = pC.Find(x => x.IPAddress == iPAddress1);
                pc1.Links.Add(iPAddress2);
                PersonalyComputer pc2 = pC.Find(x => x.IPAddress == iPAddress2);
                pc2.Links.Add(iPAddress1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintIPAddress()
        {
            foreach (PersonalyComputer pc in pC)
            {
                Console.WriteLine(pc.IPAddress);
            }
        }

        static bool TryToGetinfected(double chance)
        {
            return new Random().NextDouble() <= chance;
        }

        public bool TryGetInfectionComputer()
        {
            return pC.Exists(x => x.IsInfected);
        }

        public void Iteration()
        {
             foreach (PersonalyComputer pc in pC.FindAll(x => x.IsInfected))
             {
                 if (pc.Links != null)
                 {
                     foreach (int iP in pc.Links)
                     {
                         PersonalyComputer constrainedPC = pC.Find(x => x.IPAddress == iP);
                         if (!constrainedPC.IsInfected)
                         {
                             constrainedPC.IsInfected = TryToGetinfected(constrainedPC.OS.ChanceOfInfection);
                         }
                     }
                 }
             }
        }

        public int Run(int numberIteration = 1000)
        {
            if (!TryGetInfectionComputer())
            {
                Console.WriteLine("В сети нет зараженных компьютеров");
                return numberIteration;
            }
            else
            {
                do
                {
                    if (pC.All(x => x.IsInfected))
                    {
                        break;
                    }
                    else
                    {
                        Iteration();
                        numberIteration--;
                    }
                }
                while (numberIteration > 1);
                return numberIteration;
            }
        }

        public void ConsoleOutputInfectionComputer()
        {
            foreach (PersonalyComputer pc in pC)
            {
                if (pc.IsInfected)
                {
                    Console.Write(pc.IPAddress + " ");
                }
            }
        }
    }
}
