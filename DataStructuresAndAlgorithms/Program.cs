using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTableClass hashTable = new HashTableClass();
            hashTable.Put(6, "A");
            hashTable.Put(8, "B");
            hashTable.Put(11, "C");
            hashTable.Put(6, "A+");
            hashTable.Remove(6);
            Console.WriteLine(hashTable.Get(6));


            Console.ReadLine();
        }


    }
}
