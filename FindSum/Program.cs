using System;

namespace FindSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj n (rozmiar zbioru): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj t:");
            int t = Convert.ToInt32(Console.ReadLine());
            FindSums p = new FindSums(n, t);
            p.find_sum();
            Console.ReadLine();
        }
    }
}
