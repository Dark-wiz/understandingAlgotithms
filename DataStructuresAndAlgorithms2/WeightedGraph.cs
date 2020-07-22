using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class WeightedGraph
    {
        private class Node
        {
            public string Label { get; set; }
            public List<Edge> Edges = new List<Edge>();
            public Node(string label)
            {
                Label = label;
            }
            public override string ToString()
            {
                return Label;
            }

            public void AddEdge(Node to, int weight)
            {
                Edges.Add(new Edge(this, to, weight));
            }

            public List<Edge> GetEdges()
            {
                return Edges;
            }
        }

        private class Edge
        {
            public Node From { get; set; }
            public Node To { get; set; }
            public int Weight { get; set; }

            public Edge(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"{From} -> {To}";
            }
        }

        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Edge>> adjacencyList = new Dictionary<Node, List<Edge>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            nodes.Add(label, node);
        }

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            if (fromNode == null)
                throw new InvalidOperationException();

            var toNode = nodes.GetValueOrDefault(to);
            if (toNode == null)
                throw new InvalidOperationException();
            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public void Print()
        {
            foreach (var node in nodes.Values)
            {
                var targets = node.GetEdges();
                if (targets.Count > 0)
                    foreach (var target in targets)
                        Console.WriteLine($"{node} is connected to {target}");
            }
        }

        private class NodeEntry
        {
            public Node Node { get; set; }
            private int Priority { get; set; }

            public NodeEntry(Node node, int priority)
            {
                Node = node;
                Priority = priority;
            }
        }
        public Path GetShortestPath(string from, string to)
        {
            var fromNode = nodes.GetValueOrDefault(from);
            var toNode = nodes.GetValueOrDefault(to);
            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            foreach (var node in nodes.Values)
                distances.Add(node, int.MaxValue);
            distances.Remove(fromNode);
            distances.Add(fromNode, 0);

            Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();

            HashSet<Node> visited = new HashSet<Node>();

            Queue<NodeEntry> queue = new Queue<NodeEntry>();
            queue.Enqueue(new NodeEntry(fromNode, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue().Node;
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    if (visited.Contains(edge.To))
                        continue;

                    var newDistance = distances.GetValueOrDefault(current) + edge.Weight;
                    if (newDistance < distances.GetValueOrDefault(edge.To))
                    {
                        distances.Remove(edge.To);
                        distances.Add(edge.To, newDistance);
                        previousNodes.Remove(edge.To);

                        previousNodes.Add(edge.To, current);
                    }
                    queue.Enqueue(new NodeEntry(edge.To, newDistance));
                }
            }

            return BuildPath( toNode, previousNodes);
        }

        private Path BuildPath(Node toNode, Dictionary<Node, Node> previousNodes)
        {

            Stack<Node> stack = new Stack<Node>();
            stack.Push(toNode);
            var previous = previousNodes.GetValueOrDefault(toNode);
            while (previous != null)
            {
                stack.Push(previous);
                previous = previousNodes.GetValueOrDefault(previous);
            }
            var path = new Path();
            while (stack.Count > 0)
                path.Add(stack.Pop().Label);
            return path;
        }
    }
}
