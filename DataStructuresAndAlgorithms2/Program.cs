using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddNode("X");
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("P");
            graph.AddEdge("X", "A");
            graph.AddEdge("X", "B");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "P");
            graph.AddEdge("B", "P");

            var list = graph.TopologicalSort();
            foreach (var item in list)
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
