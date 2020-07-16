using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class PriorityQueue
    {
        private int[] items = new int[5];
        private int count;

        public void Add(int item)
        {
            if (IsFull())
                throw new InvalidOperationException();

            int i = ShiftItemsToInsert(item);
            items[i] = item;
            count++;
        }

        private bool IsFull()
        {
            return count == items.Length;
        }

        private int ShiftItemsToInsert(int item)
        {
            int i;
            for (i = count - 1; i >= 0; i--)
            {
                if (items[i] > item)
                    items[i + 1] = items[i];
                else
                    break;
            }

            return i + 1;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            return items[--count];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void ToString()
        {
            foreach (var item in items)
                Console.Write(item + " ");
        }
    }
}
