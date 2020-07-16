using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AVLTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
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
