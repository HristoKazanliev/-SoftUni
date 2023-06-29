namespace _03.Telephony
{
    using System;
    using Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] URLs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICall phone = null;
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        phone = new Smartphone();
                    }
                    else if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }

                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            IBrowse newPhone = new Smartphone();
            foreach (var URL in URLs)
            {
                try
                {
                    Console.WriteLine(newPhone.Browse(URL));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
