namespace TestSolutions
{
    using Problem01.List;

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(1);
            foreach (int i in list) 
            {
                Console.WriteLine(i);
            }
        }
    }
}