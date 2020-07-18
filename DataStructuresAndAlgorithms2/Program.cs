using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 4, 1, 2 };

            Console.WriteLine(MaxHeap.GetKthLargest(numbers, 6));
            Console.ReadLine();
        }

        public static int factorial(int val)
        {
            if (val == 0)
                return 1;
            return val * factorial(val - 1);
        }


    }
}
