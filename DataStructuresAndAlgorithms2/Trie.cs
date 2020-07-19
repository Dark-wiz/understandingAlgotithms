using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class Trie
    {
        public static int ALPHABET_SIZE = 26;
        private class Node
        {
            public char Value;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public bool IsEndOfWord;

            public Node(char value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Value " + Value;
            }

            public bool HasChild(char ch)
            {
                return children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                children.Add(ch, new Node(ch));
            }

            public Node GetChild(char ch)
            {
                return children.GetValueOrDefault(ch);
            }

            public Node[] GetChildren()
            {
                return children.Values.ToArray();
            }

            public bool HasChildren()
            {
                return children.Count > 0;
            }

            public void RemoveChild(char ch)
            {
                children.Remove(ch);
            }
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;
            var current = root;
            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    return false;
                current = current.GetChild(ch);
            }
            return current.IsEndOfWord;
        }

        private Node root = new Node(value: ' ');
        public void Insert(string word)
        {
            var current = root;
            foreach (var ch in word.ToCharArray())
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }
            current.IsEndOfWord = true;
        }

        public void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node root)
        {
            Console.WriteLine(root.Value);
            var values = root.GetChildren();
            foreach (var item in values)
            {
                Traverse(item);
            }
        }

        public void Remove(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;
            Remove(root, word, index: 0);
        }
        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }
            char ch = word.ElementAt(index);
            var child = root.GetChild(ch);
            if (child == null)
                return;
            Remove(child, word, index + 1);
            if (!child.HasChildren() && !child.IsEndOfWord)
                root.RemoveChild(ch);
        }
        public List<string> FindWords(string prefix)
        {
            List<string> words = new List<string>();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);
            return words;
        }
        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root.IsEndOfWord)
                words.Add(prefix);
            foreach (var child in root.GetChildren())
                FindWords(child, prefix + child.Value, words);
        }
        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;
            var current = root;
            foreach (var ch in prefix.ToCharArray())
            {
                var child = current.GetChild(ch);
                if (child == null)
                    return null;
                current = child;
            }
            return current;
        }
    }
}
