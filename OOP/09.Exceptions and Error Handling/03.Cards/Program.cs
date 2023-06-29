using System;
using System.Collections.Generic;

namespace _03.Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();

            foreach (var pair in input)
            {
                string[] cardInfo = pair.Split();
                string face = cardInfo[0];
                string suit = cardInfo[1];

                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }

    public class Card
    {
        private static readonly HashSet<string> faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get => this.face;
            private set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException();
                }
                face = value;
            }
        }

        public string Suit 
        {
            get => this.suit;
            private set
            {
                if (value == "S")
                {
                    suit = "\u2660";
                }
                else if (value == "H")
                {
                    suit = "\u2665";
                }
                else if (value == "D")
                {
                    suit = "\u2666";
                }
                else if (value == "C")
                {
                    suit = "\u2663";
                }
                else
                {
                    throw new ArgumentException();
                } 
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
