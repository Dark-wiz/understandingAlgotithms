using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms3
{
    public class BucketSort
    {
        public void Sort(int[] array, int noOfBuckets)
        {
            LinkedList<LinkedList<int>> buckets = CreateBuckets(array, noOfBuckets);

            var counter = 0;
            foreach (var bucket in buckets)
                //find a way to sort linked list
                foreach (var item in bucket)
                    array[counter++] = item;
        }

        private LinkedList<LinkedList<int>> CreateBuckets(int[] array, int noOfBuckets)
        {
            LinkedList<LinkedList<int>> buckets = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < noOfBuckets; i++)
                buckets.AddFirst(new LinkedList<int>());
            foreach (var item in array)
            {
                var val = buckets.ElementAt(item / noOfBuckets);
                buckets.AddFirst(val);

            }
            return buckets;
        }
    }
}
