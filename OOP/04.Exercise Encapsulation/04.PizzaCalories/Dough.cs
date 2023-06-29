using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1},
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1},
        };

        private const int CaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Calories
            => CaloriesPerGram * this.weight * modifiers[this.FlourType.ToLower()] * modifiers[this.BakingTechnique.ToLower()];

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
    }
}
