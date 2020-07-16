using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class StackClass
    {
        private int[] items = new int[5];
        private int count;

        public void push(int item)
        {
            if (count == items.Length)
                throw new StackOverflowException();
            items[count++] = item;
        }

        public int pop()
        {
            if (count == 0)
                throw new InvalidOperationException();
            return items[--count];
        }

        public int peek()
        {
            if (count == 0)
                throw new InvalidOperationException();
            return items[count - 1];
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public void toString()
        {
            int[] newItems = new int[count];
            Array.Copy(items, 0, newItems, 0, count);
            foreach (var item in newItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
