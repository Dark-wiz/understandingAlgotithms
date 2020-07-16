using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            if (input == null)
                throw new InvalidOperationException();
            Stack<Char> stack = new Stack<char>();
            foreach (var item in input.ToCharArray())
            {
                stack.Push(item);
            }
            StringBuilder reversed = new StringBuilder();
            while (stack.Count > 0 )
            {
                reversed.Append(stack.Pop());
            }
            return reversed.ToString();
        }
    }
}
