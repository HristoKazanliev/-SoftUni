using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Interfaces
{
    public class Smartphone : ICall, IBrowse
    {
        public string Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            return $"Calling... {number}";
        }

        public string Browse(string URL)
        {
            foreach (var digit in URL)
            {
                if (char.IsDigit(digit))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
            return $"Browsing: {URL}!";
        }

    }
}
