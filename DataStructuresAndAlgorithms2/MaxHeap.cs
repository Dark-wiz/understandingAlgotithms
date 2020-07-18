using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms2
{
    public class MaxHeap
    {

        public static int GetKthLargest(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new InvalidOperationException();
            var heap = new Heap();
            foreach (var number in array)
                heap.Insert(number);
            for(var i=0; i <k-1; i++)
            {
                heap.Remove();
            }
            return heap.Max();
        }
        public static void Heapify(int[] array)
        {
            int lasParentIndex = array.Length / 2 - 1;
            for (int i = lasParentIndex; i >= 0; i++)
                Heapify(array, i);

        }

        private static void Heapify(int[] array, int index)
        {
            var largerIndex = index;
            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);

        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
