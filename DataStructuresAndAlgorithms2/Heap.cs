using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class Heap
    {
        private int[] items = new int[10];
        private int size;

        public void Insert(int val)
        {
            if (IsFull())
                throw new InvalidOperationException("Heap is Full");
            items[size++] = val;
            BubbleUp();

        }
        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");
            return items[0];
        }
        private bool IsFull()
        {
            return size == items.Length;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }
        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            var root = items[0];
            items[0] = items[--size];
            BubbleDown();
            return root;
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValidParent(index))
            {
                var largerChildIndex = GetLargerChildIndex(index);

                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private int GetLargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index))
                ? LeftChildIndex(index) : RightChildIndex(index);
        }


        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = items[index] >= LeftChild(index);
            if (HasRightChild(index))
                isValid &= items[index] >= RightChild(index);
            return isValid;
        }

        private int LeftChild(int index)
        {
            return items[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return items[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
