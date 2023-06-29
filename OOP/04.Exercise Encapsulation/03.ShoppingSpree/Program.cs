using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            try
            {
                string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var person in peopleInput)
                {
                    string[] personData = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Person person1 = new Person(personData[0], decimal.Parse(personData[1]));
                    peopleList.Add(person1);
                }

                string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var product in productInput)
                {
                    string[] productData = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product1 = new Product(productData[0], decimal.Parse(productData[1]));
                    productsList.Add(product1);
                }

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] shopping = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person person = peopleList.Find(p => p.Name == shopping[0]);
                    Product product = productsList.Find(p => p.Name == shopping[1]);

                    person.BuyProduct(product);
                    input = Console.ReadLine();
                }

                foreach (var person in peopleList)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
