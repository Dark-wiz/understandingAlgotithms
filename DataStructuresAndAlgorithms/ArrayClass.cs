using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{

    public class ArrayClass
    {
        private int[] items;
        private int count;
        public ArrayClass(int length)
        {
            items = new int[length];
        }

        public void print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(items[i]);

            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                    return i;
            }
            return -1;
        }

        public void Insert(int item)
        {
            if (items.Length == count)
            {
                int[] newItems = new int[count * 2];

                for (int i = 0; i < count; i++)
                {
                    newItems[i] = items[i];
                }
                items = newItems;
            }

            //add new item to end and increment count by 1 to keep track of the size
            items[count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArithmeticException();
            for (int i = index; i < count; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
        }

        public int Max()
        {
            int larger = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] > larger)
                {
                    larger = items[i];
                }
            }
            return larger;
        }

        public void intersect()
        {

        }

        public int[] Reverse()
        {
            int[] newArray = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = items.Length-1; j > items.Length; j--)
                {
                    newArray[i] = items[j];
                }
            }
            return newArray;
        }

        public void InsertAt(int item, int index)
        {
            items[index] = item;
        }
    }
}
