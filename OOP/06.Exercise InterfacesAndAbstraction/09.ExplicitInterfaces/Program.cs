using System;

namespace _09.ExplicitInterfaces
{
    using Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] inputArr = command.Split();
                string name = inputArr[0];
                string country = inputArr[1];
                int age = int.Parse(inputArr[2]);

                //IPerson person = new Citizen(name, country, age);
                //IResident resident = new Citizen(name, country, age);

                //Console.WriteLine(person.GetName());
                //Console.WriteLine(resident.GetName());

                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());

                command = Console.ReadLine();
            }
        }
    }
}
