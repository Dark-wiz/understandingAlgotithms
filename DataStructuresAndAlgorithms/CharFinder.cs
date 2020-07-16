using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class CharFinder
    {
        public char FindFirstNonRepeatingChar(string str)
        {
            Dictionary<Char, int> map = new Dictionary<char, int>();
            foreach (var item in str)
            {
                var count = map.ContainsKey(item) ? map.GetValueOrDefault(item) : 0;
                bool check = map.ContainsKey(item);
                if (check)
                {
                    var value = map.GetValueOrDefault(item);
                    map[item] = value+1;
                }
                else
                    map.Add(item, count + 1);
            }
            foreach (var item in str)
                if (map[item] == 1)
                    return item;
            return Char.MinValue;
        }

        public char FindFirstRepeatedChar(string str)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var item in str)
            {
                if (set.Contains(item))
                    return item;
                set.Add(item);
            }
            return char.MinValue;
        }
    }
}
