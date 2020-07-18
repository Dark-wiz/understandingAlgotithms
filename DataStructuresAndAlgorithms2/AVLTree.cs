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
            SetHeight(root);       
            return Balance(root);
        }
        private AVLNode RotateLeft(AVLNode root)
        {
            var newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }

        private AVLNode RotateRight(AVLNode root)
        {
            var newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }


        private void SetHeight(AVLNode node)
        {
            node.Height = Math.Max(Height(node.LeftChild), Height(node.RightChild)) + 1;
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.LeftChild) < 0)
                    root.LeftChild = RotateLeft(root.LeftChild);
                return RotateRight(root);

            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.RightChild) > 0)
                    root.RightChild = RotateRight(root.RightChild);
                return RotateLeft(root);
            }
            return root;
        }
        private bool IsLeftHeavy(AVLNode node)
        {
            return BalanceFactor(node) > 1;
        }
        private bool IsRightHeavy(AVLNode node)
        {
            return BalanceFactor(node) < -1;
        }
        private int BalanceFactor(AVLNode node)
        {
            return (node == null) ? 0 : Height(node.LeftChild) - Height(node.RightChild);
        }
        private int Height(AVLNode node)
        {
            return (node == null ? -1 : node.Height);
        }
    }
}
