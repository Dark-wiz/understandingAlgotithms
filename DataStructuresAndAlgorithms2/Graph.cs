using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class Graph
    {
        private class Node
        {
            public string Label { get; set; }

            public Node(string label)
            {
                Label = label;
            }
            public override string ToString()
            {
                return Label;
            }
        }
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            var node = new Node(label);
            nodes.Add(label, node);
            adjacencyList.Add(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = nodes.GetValueOrDefault(to);
            if (toNode == null)
                throw new InvalidOperationException();
            adjacencyList.GetValueOrDefault(fromNode).Add(toNode);
        }

        public void Print()
        {
            foreach (var item in adjacencyList.Keys)
            {
                var targets = adjacencyList.GetValueOrDefault(item);
                if (targets.Count > 0)
                    foreach (var target in targets)
                        Console.WriteLine($"{item} is connected to {target}");
            }
        }

        public void RemoveNode(string label)
        {
            var node = nodes.GetValueOrDefault(label);
            if (node == null)
                return;

            foreach (var item in adjacencyList.Keys)
                adjacencyList.GetValueOrDefault(item).Remove(node);
            adjacencyList.Remove(node);
            nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            var toNode = nodes.GetValueOrDefault(to);

            if (fromNode == null || toNode == null)
                return;
            adjacencyList.GetValueOrDefault(fromNode).Remove(toNode);
        }

        public bool HasCycle()
        {
            HashSet<Node> all = new HashSet<Node>();
            foreach (var item in nodes.Values)
                all.Add(item);

            HashSet<Node> visiting = new HashSet<Node>();
            HashSet<Node> visited = new HashSet<Node>();

            while (all.Count > 0)
            {
                var current = all.ToArray()[0];
                if (HasCycle(current, all, visiting, visited))
                    return true;
            }
            return false;

        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);

            foreach (var neighbour in adjacencyList.GetValueOrDefault(node))
            {
                if (visited.Contains(neighbour))
                    continue;
                if (visiting.Contains(neighbour))
                    return true;

                if (HasCycle(neighbour, all, visiting, visited))
                    return true;
            }
            visiting.Remove(node);
            visited.Add(node);
            return false;
        }

        public void TraverseDepthFirstRecursive(string root)
        {
            var node = nodes.GetValueOrDefault(root);
            if (node == null)
                return;
            TraverseDepthFirstRecursive(node, new HashSet<Node>());
        }

        private void TraverseDepthFirstRecursive(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root);
            visited.Add(root);
            foreach (var node in adjacencyList.GetValueOrDefault(root))
            {
                if (!visited.Contains(node))
                    TraverseDepthFirstRecursive(node, visited);
            }
        }

        public void TraverseDepthFirst(string root)
        {
            var node = nodes.GetValueOrDefault(root);
            if (node == null)
                return;

            HashSet<Node> visited = new HashSet<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);


            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current);
                visited.Add(current);


                foreach (var neighbour in adjacencyList.GetValueOrDefault(current))
                    if (!visited.Contains(node))
                        stack.Push(neighbour);
            }
        }

        public void TraverseBreadthFirst(string root)
        {
            var node = nodes.GetValueOrDefault(root);
            if (node == null)
                return;

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (visited.Contains(current))
                    continue;
                Console.WriteLine(current);
                visited.Add(current);
                foreach (var neighbour in adjacencyList.GetValueOrDefault(current))
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
            }
        }
        public List<string> TopologicalSort()
        {
            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visited = new HashSet<Node>();
            foreach (var node in nodes.Values)
                TopologicalSort(node, visited, stack);
            List<string> sorted = new List<string>();
            while (stack.Count > 0)
                sorted.Add(stack.Pop().Label);
            return sorted;
        }
        private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(node))
                return;
            visited.Add(node);

            foreach (var neighbor in adjacencyList.GetValueOrDefault(node))
                TopologicalSort(neighbor, visited, stack);
            stack.Push(node);
        }
    }
}
