using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms2
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddEdge("A", "B", 3);
            graph.AddEdge("B", "D", 4);
            graph.AddEdge("C", "D", 5);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("B", "C", 2);
            graph.GetMinimumSpanningTree();
            graph.Print();

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
