using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class ArrayQueue
    {
        private int[] items;
        private int rear;
        private int front;
        private int count;
        public ArrayQueue(int capacity)
        {
            items = new int[capacity];
        }

        public void Enqueue(int item)
        {
            if (items.Length == count)
                throw new InvalidOperationException();   
            items[rear] = item;
            rear = (rear + 1) % items.Length; 
            count++;
        }
        public  int Dequeue()  
        {
            var item = items[front];
            items[front] = 0;
            front = (front + 1) % items.Length;
            count--;
            return item;
        }
        public void ToString()
        {
            foreach (var item in items)
                Console.Write(item + " ");
        }

        public void ReverseEx(Queue queue)
        {
            if (queue.Count == 0)
                throw new InvalidOperationException();
            Stack stack = new Stack();
            foreach (var item in queue)
                stack.Push(item);

            foreach (var item in stack)
                Console.Write(item + " ");
        }
        public void Reverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
                stack.Push(queue.Dequeue());
            while (queue.Count > 0)
                queue.Enqueue(stack.Pop());
        }
    }
}
