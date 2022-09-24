using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    //Heaps are complete binary tree hence height = log(n)
    public class MinHeap
    {
        public IList<int> minHeap = new List<int>();

        public int peek()
        {
            if (minHeap.Count < 1) return -1;
            return minHeap[0];
        }

        public int size()
        {
            return minHeap.Count;
        }

        public void add(int val)
        {
            minHeap.Add(val);
            upheapify(minHeap.Count - 1);
        }

        public int remove()
        {
            if (minHeap.Count < 1) return -1;

            int val = minHeap[0];
            minHeap.RemoveAt(0);
            downheapify(0);
            return val;
        }

        private void downheapify(int pi)
        {
            int min = pi;

            int leftIndex = 2 * pi + 1;

            if (leftIndex < minHeap.Count && minHeap[leftIndex] < minHeap[min])
            {
                min = leftIndex;
            }

            int rightIndex = 2 * pi + 2;

            if (rightIndex < minHeap.Count && minHeap[rightIndex] < minHeap[min])
            {
                min = rightIndex;
            }

            if(min != pi)
            {
                swap(min, pi);
                downheapify(min);
            }

        }


        private void upheapify(int i)
        {
            if (i == 0)
            {
                return;
            }
            int parent = (i - 1) / 2;

            if (minHeap[parent] > minHeap[i])
            {
                swap(parent, i);
                upheapify(parent);
            }
        }

        private void swap(int parent, int i)
        {
            int temp = minHeap[i];
            minHeap[i] = minHeap[parent];
            minHeap[parent] = temp;
        }

    }
}
