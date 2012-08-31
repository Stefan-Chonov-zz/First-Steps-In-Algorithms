using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSortRecursive
{
    class QuickSortAlgorithm
    {
        static void Main(string[] args)
        {
            int[] unsortedSequence = 
            {
                1, 14, 9, 15,30,39,25, 48
                //3, 34, 6, 23, 12, 1, 3, 2, 65,
            };

            QuickSort(unsortedSequence, 0, unsortedSequence.Length - 1);
        }

        public static void QuickSort(int[] sequence, int leftIndex, int rightIndex)
        {
            int initialLeftIndex = leftIndex;
            int initialRightIndex = rightIndex;
            int pivotValue = sequence[leftIndex];

            while (leftIndex < rightIndex)
            {
                while ((pivotValue < sequence[rightIndex]) && 
                       (rightIndex != leftIndex))
                {
                    rightIndex--;
                }

                if (leftIndex != rightIndex)
                {
                    sequence[leftIndex] = sequence[rightIndex];                 
                    leftIndex++;
                }

                while ((sequence[leftIndex] < pivotValue) && 
                       (rightIndex != leftIndex))
                {
                    leftIndex++;
                }

                if (rightIndex != leftIndex)
                {
                    sequence[rightIndex] = sequence[leftIndex];
                    rightIndex--;
                }
            }

            sequence[leftIndex] = pivotValue;

            if (leftIndex - 1 > initialLeftIndex)
            {
                QuickSort(sequence, initialLeftIndex, leftIndex - 1);
            }

            if (leftIndex + 1 < initialRightIndex)
            {
                QuickSort(sequence, leftIndex + 1, initialRightIndex);
            }
        }
    }
}
