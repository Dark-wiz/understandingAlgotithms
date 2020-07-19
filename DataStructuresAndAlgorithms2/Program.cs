using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("cat");
            trie.Insert("care");
            trie.Insert("fan");
            trie.Insert("adult");

            var words = trie.FindWords("");
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
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
