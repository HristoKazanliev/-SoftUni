using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();
            IIdentifiable identifiable = null;
            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArray.Length==3)
                {
                    string name = inputArray[0];
                    int age = int.Parse(inputArray[1]);
                    string id = inputArray[2];

                    identifiable = new Citizen(name, age, id);
                }
                else
                {
                    string model = inputArray[0];
                    string id = inputArray[1];

                    identifiable = new Robot(model, id);
                }

                list.Add(identifiable);
                input = Console.ReadLine();
            }

            string fakeIDNums = Console.ReadLine();

            List<string> fakeIDs = list.Where(x => x.Id.EndsWith(fakeIDNums)).Select(x=> x.Id).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, fakeIDs));
        }
    }
}
