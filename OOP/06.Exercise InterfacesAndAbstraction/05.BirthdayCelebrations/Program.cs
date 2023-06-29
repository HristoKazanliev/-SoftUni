using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdate> list = new List<IBirthdate>();
            IBirthdate identifiable = null;
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = inputArray[0];

                if (type == "Citizen")
                {
                    string name = inputArray[1];
                    int age = int.Parse(inputArray[2]);
                    string id = inputArray[3];
                    string birthdate = inputArray[4];

                    identifiable = new Citizen(name, age, id, birthdate);
                }
                else if (type =="Pet")
                {
                    string name = inputArray[1];
                    string birthday = inputArray[2];

                    identifiable = new Pet(name, birthday);
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                

                list.Add(identifiable);
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            List<string> fakeIDs = list.Where(x => x.Birthdate.EndsWith(year)).Select(x => x.Birthdate).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, fakeIDs));
        }
    }
}
