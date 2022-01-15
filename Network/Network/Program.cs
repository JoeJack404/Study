using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class Program
    {
        static void Main(string[] args)
        {
            MacOS macOS = new MacOS();
            LinOS linOS = new LinOS();
            WinOS winOS = new WinOS();
            Network network = new Network();
            PersonalyComputer personalyComputer1 = new PersonalyComputer(macOS, true);
            network.Add(personalyComputer1, 1);
            PersonalyComputer personalyComputer2 = new PersonalyComputer(macOS);
            network.Add(personalyComputer2, 2);
            PersonalyComputer personalyComputer3 = new PersonalyComputer(macOS);
            network.Add(personalyComputer3, 3);
            PersonalyComputer personalyComputer4 = new PersonalyComputer(macOS);
            network.Add(personalyComputer4, 4);
            PersonalyComputer personalyComputer5 = new PersonalyComputer(macOS);
            network.Add(personalyComputer5, 5);
            PersonalyComputer personalyComputer6 = new PersonalyComputer(macOS);
            network.Add(personalyComputer6, 6);
            PersonalyComputer personalyComputer7 = new PersonalyComputer(macOS);
            network.Add(personalyComputer7, 7);
            PersonalyComputer personalyComputer8 = new PersonalyComputer(macOS);
            network.Add(personalyComputer8, 8);
            PersonalyComputer personalyComputer9 = new PersonalyComputer(macOS);
            network.Add(personalyComputer9, 9);
            PersonalyComputer personalyComputer10 = new PersonalyComputer(winOS);
            network.Add(personalyComputer10, 10);
            PersonalyComputer personalyComputer11 = new PersonalyComputer(winOS);
            network.Add(personalyComputer11, 11);
            PersonalyComputer personalyComputer12 = new PersonalyComputer(winOS);
            network.Add(personalyComputer12, 12);
            PersonalyComputer personalyComputer13 = new PersonalyComputer(winOS);
            network.Add(personalyComputer13, 13);
            PersonalyComputer personalyComputer14 = new PersonalyComputer(winOS);
            network.Add(personalyComputer14, 14);
            PersonalyComputer personalyComputer15 = new PersonalyComputer(winOS);
            network.Add(personalyComputer15, 15);
            PersonalyComputer personalyComputer16 = new PersonalyComputer(winOS);
            network.Add(personalyComputer16, 16);
            PersonalyComputer personalyComputer17 = new PersonalyComputer(winOS);
            network.Add(personalyComputer17, 17);
            PersonalyComputer personalyComputer18 = new PersonalyComputer(winOS);
            network.Add(personalyComputer18, 18);
            PersonalyComputer personalyComputer19 = new PersonalyComputer(linOS);
            network.Add(personalyComputer19, 19);
            PersonalyComputer personalyComputer20 = new PersonalyComputer(linOS);
            network.Add(personalyComputer20, 20);
            PersonalyComputer personalyComputer21 = new PersonalyComputer(linOS);
            network.Add(personalyComputer21, 21);
            PersonalyComputer personalyComputer22 = new PersonalyComputer(linOS);
            network.Add(personalyComputer22, 22);
            PersonalyComputer personalyComputer23 = new PersonalyComputer(linOS);
            network.Add(personalyComputer23, 23);
            PersonalyComputer personalyComputer24 = new PersonalyComputer(linOS);
            network.Add(personalyComputer24, 24);
            PersonalyComputer personalyComputer25 = new PersonalyComputer(linOS);
            network.Add(personalyComputer25, 25);
            PersonalyComputer personalyComputer26 = new PersonalyComputer(linOS);
            network.Add(personalyComputer26, 26);
            PersonalyComputer personalyComputer27 = new PersonalyComputer(linOS);
            network.Add(personalyComputer27, 27);
            network.TryAddLink(1, 5);
            network.TryAddLink(1, 6);
            network.TryAddLink(1, 12);
            network.TryAddLink(1, 16);
            network.TryAddLink(1, 17);
            network.TryAddLink(1, 21);
            network.TryAddLink(1, 22);
            network.TryAddLink(1, 26);
            network.TryAddLink(1, 27);
            network.TryAddLink(2, 4);
            network.TryAddLink(2, 6);
            network.TryAddLink(2, 11);
            network.TryAddLink(2, 12);
            network.TryAddLink(2, 21);
            network.TryAddLink(2, 19);
            network.TryAddLink(2, 27);
            network.TryAddLink(3, 4);
            network.TryAddLink(3, 7);
            network.TryAddLink(3, 13);
            network.TryAddLink(3, 14);
            network.TryAddLink(3, 15);
            network.TryAddLink(3, 18);
            network.TryAddLink(3, 20);
            network.TryAddLink(4, 3);
            network.TryAddLink(4, 5);
            network.TryAddLink(4, 15);
            network.TryAddLink(4, 17);
            network.TryAddLink(4, 23);
            network.TryAddLink(4, 24);
            network.TryAddLink(4, 25);
            network.TryAddLink(4, 26);
            network.TryAddLink(4, 27);
            network.TryAddLink(4, 9);
            network.TryAddLink(4, 8);
            network.TryAddLink(4, 18);
            network.TryAddLink(4, 19);
            network.TryAddLink(4, 10);
            network.TryAddLink(4, 30);
            Console.WriteLine("Введите число итераций");
            Console.Write("(По умолчанию 1000, введите 0, чтобы оставить это число)");
            Console.WriteLine();
            int numberIteration = Convert.ToInt32(Console.ReadLine());
            int numberIterationReal = -1;
            if (numberIteration == 0)
            {
                int numberIterationStop = network.Run();
                numberIterationReal = 1000 - numberIterationStop + 1;
            }
            else
            {
                int numberIterationStop = network.Run(numberIteration);
                numberIterationReal = numberIteration - numberIterationStop + 1;
                if (network.TryGetInfectionComputer())
                {
                    Console.WriteLine("Все компьютеры зараженны");
                }
            }
            int numberInfection = network.NumberOfInfection();
            Console.WriteLine("Количество зараженных компьютеров: {0} (всего 27 компьютеров), количество совершенных итераций: {1}",numberInfection, numberIterationReal);
            Console.WriteLine();
            Console.WriteLine("IP адреса зараженных компьютеров:");
            network.ConsoleOutputInfectionComputer();
            Console.ReadLine();
        }
    }
}
