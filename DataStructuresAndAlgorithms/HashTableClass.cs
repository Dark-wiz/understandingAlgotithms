using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class HashTableClass
    {
        private class Entry
        {
            public int key { get; set; }
            public string value { get; set; }
            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }
        private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

        //public void Put(int key, string value)
        //{
        //    var index = hash(key);
        //    if (entries[index] == null)
        //        entries[index] = new LinkedList<Entry>();

        //    var bucket = entries[index];
        //    foreach (var item in bucket)
        //    {
        //        if (item.key == key)
        //        {
        //            item.value = value;
        //            return;
        //        }
        //    }
        //    bucket.AddLast(new Entry(key, value));
        //}

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return (entry == null) ? null : entry.value;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new InvalidOperationException();
            GetBucket(key).Remove(entry);
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            var index = hash(key);
            var bucket = entries[index];
            return bucket;
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);
            if(bucket != null)
            {
                foreach (var entry in bucket)
                {
                    if (entry.key == key)
                        return entry;
                }
            }
            return null;
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = hash(key);
            var bucket = entries[index];
            if (bucket == null)
            {
                entries[index] = new LinkedList<Entry>();
                bucket = entries[index];
            }
            return bucket;
        }
        private int hash(int key)
        {
            return key % entries.Length;
        }
    }
}
