using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Interfaces
{
    public class StationaryPhone : ICall
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
            return $"Dialing... {number}";
        }
    }
}
