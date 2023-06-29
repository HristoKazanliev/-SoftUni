using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = Console.ReadLine();

            while (!command.Equals("Beast!"))
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    Animal animal = null;
                    if (command.Equals("Dog"))
                    {
                        string gender = animalInfo[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (command.Equals("Cat"))
                    {
                        string gender = animalInfo[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (command.Equals("Frog"))
                    {
                        string gender = animalInfo[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (command.Equals("Kitten"))
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (command.Equals("Tomcat"))
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid type!");
                    }

                    animals.Add(animal);
                    command = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }    
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
