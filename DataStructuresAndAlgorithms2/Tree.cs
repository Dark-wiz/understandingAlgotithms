using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class Tree
    {
        public class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Node = " + Value;
            }
        }
        public Node Root { get; set; }
        public void Insert(int value)
        {
            var node = new Node(value);
            if (Root == null)
            {
                Root = node;
                return;
            }

            var current = Root;
            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        break;
                    }
                    current = current.LeftChild;

                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        break;
                    }
                    current = current.RightChild;

                }
            }
        }

        public bool Find(int value)
        {
            var current = Root;
            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;
                else if (value > current.Value)
                    current = current.RightChild;
                else
                    return true;
            }
            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.Value);
            TraversePreOrder(node.LeftChild);
            TraversePreOrder(node.RightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }
        private void TraverseInOrder(Node node)
        {
            if (node == null)
                return;
            TraverseInOrder(node.LeftChild);
            Console.WriteLine(node.Value);
            TraverseInOrder(node.RightChild);

        }
        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }
        private void TraversePostOrder(Node node)
        {
            if (node == null)
                return;
            TraverseInOrder(node.LeftChild);
            TraverseInOrder(node.RightChild);
            Console.WriteLine(node.Value);
        }

        public void TraverseLevelOrder()
        {
            for (int i = 0; i <= Height(); i++)
            {
                foreach(var value in GetNodesAtDistance(i))
                    Console.WriteLine(value);
            }
        }


        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(Root, distance, list);
            return list;
        }
        private void GetNodesAtDistance(Node node, int distance, List<int> list)
        {
            if (node == null)
                return;
            if (distance == 0)
            {
                list.Add(node.Value);
                return;
            }
            GetNodesAtDistance(node.LeftChild, distance - 1, list);
            GetNodesAtDistance(node.RightChild, distance - 1, list);
        }
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }
        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node == null)
                return true;
            if (node.Value < min || node.Value > max)
                return false;
            return IsBinarySearchTree(node.LeftChild, min, node.Value - 1)
                && IsBinarySearchTree(node.RightChild, node.Value + 1, max);
        }

        public bool Equals(Tree other)
        {
            if (other == null)
                return false;
            return Equals(Root, other.Root);
        }
        //pre-order traversal
        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;
            if (first != null && second != null)
                return first.Value == second.Value
                    && Equals(first.LeftChild, second.LeftChild)
                    && Equals(first.RightChild, second.RightChild);
            return false;
        }

        //for binary search tree, 0(log n)
        public int Min()
        {
            if (Root == null)
                throw new NullReferenceException("Tree is empty");
            var current = Root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }
            return last.Value;
        }
        //for non binary serch tree
        //public int Min()
        //{
        //    return Min(Root);
        //}

        //0(n)
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }


        public int Height()
        {
            return Height(Root);
        }
        private int Height(Node root)
        {
            if (root == null)
                return -1;
            if (IsLeaf(root))
                return 0;
            return 1 + Math.Max(
                Height(root.LeftChild),
                Height(root.RightChild));
        }
        private bool IsLeaf(Node root)
        {
            return root.LeftChild == null && root.RightChild == null;
        }
    }
}
