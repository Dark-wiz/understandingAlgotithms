using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms3
{
    public class CountingSort
    {
        public void Sort(int[] array, int max)
        {
            int[] counts = new int[max + 1];
            foreach (var item in array)
                counts[item]++;
            int k = 0;
            for (int i = 0; i < counts.Length; i++)
                for (int j = 0; j < counts[i]; j++)
                    array[k++] = i;
        }
    }
}
