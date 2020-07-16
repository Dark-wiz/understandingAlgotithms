using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class AVLTree
    {
        private class AVLNode
        {
            public int Height { get; set; }
            public int Value { get; set; }
            public AVLNode LeftChild { get; set; }
            public AVLNode RightChild { get; set; }

            public AVLNode(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "value " + Value;
            }
        }
        private AVLNode root;
        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private AVLNode Insert(AVLNode root, int value)
        {
            if (root == null)
                return new AVLNode(value);
            if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);
            else
                root.RightChild = Insert(root.RightChild, value);
            root.Height = Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
            return root;
        }

        private int Height(AVLNode node)
        {
            return (node == null ? -1 : node.Height);
        }
    }
}
