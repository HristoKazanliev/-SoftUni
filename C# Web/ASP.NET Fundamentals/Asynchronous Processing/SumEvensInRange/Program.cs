namespace SumEvensInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                var cmd = Console.ReadLine();
                if (cmd == "show") 
                {
                    var result = SumAsync();
                    Console.WriteLine(result);
                }
            }
        }

        private static long SumAsync()
        {
            return Task.Run(() =>
            {
                long sum = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(sum += i);
                    }
                }

                return sum;
            }).Result;
        }
    }
}