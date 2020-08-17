using System;

namespace DataStructuresAndAlgorithms3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 7, 3, 9, 5, 2, 8 };
            Search search = new Search();
            Console.WriteLine(search.ExponentialSearch(num, 8));
            Console.ReadLine();
        }
    }
}
