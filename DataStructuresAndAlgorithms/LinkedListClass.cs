using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class LinkedListClass
    {
        private class Node
        {
            public int Value;
            public Node Next;

            public Node(int value)
            {
                this.Value = value;

            }
        }
        private Node First;
        private Node Last;
        private int size;
        public void AddFirst(int item)
        {
            Node node = new Node(item);
            if (isEmpty())
                First = Last = node;
            else
            {
                node.Next = First;
                First = node;
            }
            size++;
        }
        public void AddLast(int item)
        {
            Node node = new Node(item);
            if (isEmpty())
                First = Last = node;
            else
            {
                Last.Next = node;
                Last = node;
            }
            size++;
        }
        public void RemoveFirst()
        {
            if (isEmpty())
                throw new InvalidOperationException();
            if (First == Last)
                First = Last = null;
            else
            {
                var second = First.Next;
                First.Next = null;
                First = second;
            }
            size--;
        }
        public void RemoveLast()
        {
            if (isEmpty())
                throw new InvalidOperationException();
            if (First == Last)
                First = Last = null;
            else
            {
                var previous = GetPrevious(Last);
                Last = previous;
                Last.Next = null;
            }
            size--;
        }
        public bool Contains(int item)
        {
            return IndexOf(item) != -1;

        }
        public int IndexOf(int item)
        {
            int index = 0;
            Node current = First;
            while (current != null)
            {
                if (current.Value == item)
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public int Size()
        {
            return size;
        }


        private Node GetPrevious(Node node)
        {
            var current = First;
            while (current != null)
            {
                if (current.Next == node)
                    return current;
                current = current.Next;
            }
            return null;
        }

        private bool isEmpty()
        {
            return First == null;
        }

        public void Reverse()
        {
            if (isEmpty())
                return;
            var previous = First;
            var current = First.Next;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            Last = First;
            Last.Next = null;
            First = previous;
        }

        public void ReverseExercise()
        {
            //[10->20->30]
            if (isEmpty())
                throw new InvalidOperationException();
            Node node1;
            while (First.Next != null)
            {
                node1 = Last;
                Node previous = GetPrevious(node1);
                Last.Next = previous;
                First.Next = null;
            }
        }

        public int GetKthFromTheEnd(int k)
        {
            if(isEmpty())
                throw new InvalidOperationException();
            var a = First;
            var b = First;
            for (int i = 0; i < k - 1; i++)
            {
                b = b.Next;
                if (b == null)
                    throw new InvalidOperationException();
            }
            while (b != Last)
            {
                a = a.Next;
                b = b.Next;
            }
            return a.Value;
        }

        public void PrintMiddle()
        {
            if (isEmpty())
                throw new InvalidOperationException();
            var a = First;
            var b = First;

            while (b != Last && b.Next != Last)
            {
                b = b.Next.Next;
                a = a.Next;
            }

            if(b==Last)
                Console.WriteLine(a.Value);
            else
                Console.WriteLine(a.Value + " " + a.Next.Value);

        }
        public int[] ToArray()
        {
            int[] array = new int[size];
            var current = First;
            var index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }

    }
}
