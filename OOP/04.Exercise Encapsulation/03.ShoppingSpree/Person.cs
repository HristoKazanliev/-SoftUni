using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products => products;

        public string Name
        {
            get 
            { 
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }


        public decimal Money
        {
            get 
            { 
                return this.money; 
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.products.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            return this.Products.Count > 0
                ? $"{this.Name} - {string.Join(", ", products.Select(p => p.Name))}"
                : $"{this.Name} - Nothing bought";
        }

    }
}
