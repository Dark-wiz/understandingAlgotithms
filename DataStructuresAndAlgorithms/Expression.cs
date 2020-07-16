using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class Expression
    {
        private char[] leftBrackets = new char[] { '(', '<', '[', '{' };
        private char[] rightBrackets = new char[] { ')', '>', ']', '}' };
        public bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var ch in input.ToCharArray())
            {
                if (IsLeftBracket(ch))
                    stack.Push(ch);
                if (IsRightBracket(ch))
                {
                    if (stack.Count == 0)
                        return false;
                    var top = stack.Pop();
                    if (!BracketMatch(top, ch))
                        return false;
                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;
        }

        private bool IsLeftBracket(char ch)
        {
            return leftBrackets.Contains(ch);
        }

        private bool IsRightBracket(char ch)
        {
            return rightBrackets.Contains(ch);
        }

        private bool BracketMatch(char left, char right)
        {
            var leftList = leftBrackets.ToList();
            var rightList = rightBrackets.ToList();
            return leftList.IndexOf(left) == rightList.IndexOf(right);
        }
    }
}
