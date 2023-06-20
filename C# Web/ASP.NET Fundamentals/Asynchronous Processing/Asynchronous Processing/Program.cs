namespace Asynchronous_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() => PrintEvenNumbers(start,end));
            thread.Start();
            thread.Join();
            Console.WriteLine("Thread finished work ");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++) 
            {
                if (i % 2 == 0) Console.WriteLine(i);
            }
        }
    }
}