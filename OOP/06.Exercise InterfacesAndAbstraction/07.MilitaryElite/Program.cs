using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Classes;
using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            string input = Console.ReadLine();
            while (input !="End")
            {
                string[] soldierInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string rankOfSoldier = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];
                decimal salary = decimal.Parse(soldierInfo[4]);

                if (rankOfSoldier == "Private")
                {
                    ISoldier @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id,@private);
                }
                else if (rankOfSoldier == "LieutenantGeneral")
                {
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        string idToLookFor = soldierInfo[i];
                        IPrivate currentSoldier = (IPrivate)soldiers[idToLookFor];
                        lieutenantGeneral.Privates.Add(currentSoldier);
                    }
                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (rankOfSoldier == "Engineer")
                {
                    string corpsAsString = soldierInfo[5];

                    if (!Enum.IsDefined(typeof(Corps), corpsAsString))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, Enum.Parse<Corps>(corpsAsString));

                    for (int i = 6; i < soldierInfo.Length; i+=2)
                    {
                        string partName = soldierInfo[i];
                        int hoursWorked = int.Parse(soldierInfo[i + 1]);

                        Repair repair = new Repair(partName, hoursWorked);
                        engineer.Repairs.Add(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (rankOfSoldier == "Commando")
                {
                    string corpsAsString = soldierInfo[5];

                    if (!Enum.IsDefined(typeof(Corps), corpsAsString))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, Enum.Parse<Corps>(corpsAsString));

                    for (int i = 6; i < soldierInfo.Length; i+=2)
                    {
                        string codeName = soldierInfo[i];
                        string statusAsString = soldierInfo[i + 1];

                        if (Enum.IsDefined(typeof(State), statusAsString))
                        {
                            IMission mission = new Mission(codeName, Enum.Parse<State>(statusAsString));
                            commando.Missions.Add(mission);
                        }
                    }

                    soldiers.Add(id, commando);
                }
                else if (rankOfSoldier == "Spy")
                {
                    int codeNumber = int.Parse(salary.ToString());
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id, spy);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
