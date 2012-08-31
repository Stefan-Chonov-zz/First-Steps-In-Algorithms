using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            int[] unsortedSequence = 
            {
                //6, 3, 76, 43, 2, 1, 54,0, -65,
               1, 14, 9, 15,30,39,25, 48
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(unsortedSequence, 0, unsortedSequence.Length - 1);
            sw.Stop();
            long quicksort = sw.ElapsedTicks;

            sw = new Stopwatch();
            sw.Start();
            int result = BinarySearch(unsortedSequence, 25);
            sw.Stop();
            long elapsedTime = sw.ElapsedTicks;

            sw = new Stopwatch();
            sw.Start();
            int result2 = BinarySearchRecursive(unsortedSequence, 140, 0, unsortedSequence.Length);
            sw.Stop();
            long elapsedTime2 = sw.ElapsedTicks;

            Console.WriteLine("Quicksort Non-recursive: {0}", quicksort);
            Console.WriteLine("Non-Recursive stopwatch time: {0}", elapsedTime);
            Console.WriteLine("Recursive stopwatch time: {0}", elapsedTime2);
        }

        public static void QuickSort(int[] unsoredSequence, int leftIndex, int rightIndex)
        {            
            int pivot = unsoredSequence[leftIndex];
            int initialLeftIndex = leftIndex;
            int initialRightIndex = rightIndex;
            
            while (leftIndex < rightIndex)
            {
                while ((unsoredSequence[rightIndex] > pivot) && 
                       (leftIndex != rightIndex))
                {
                    rightIndex--;
                }

                if (leftIndex != rightIndex)
                {
                    unsoredSequence[leftIndex] = unsoredSequence[rightIndex];
                    leftIndex++;
                }

                while ((unsoredSequence[leftIndex] < pivot) && 
                       (leftIndex != rightIndex))
                {
                    leftIndex++;
                }

                if (leftIndex != rightIndex)
                {
                    unsoredSequence[rightIndex] = unsoredSequence[leftIndex];
                    rightIndex--;
                }                
            }

            unsoredSequence[leftIndex] = pivot;

            if (leftIndex - 1 >= initialLeftIndex)
            {
                QuickSort(unsoredSequence, initialLeftIndex, leftIndex - 1);
            }
            
            if (leftIndex + 1 < initialRightIndex)
            {
                QuickSort(unsoredSequence, leftIndex + 1, initialRightIndex);
            }
        }

        public static int BinarySearch(int[] sequence, int element)
        {
            int startIndex = 0;
            int endIndex = sequence.Length;

            while (startIndex + 1 < endIndex)
            {
                int middleIndex = (endIndex + startIndex) >> 1;
                int middleElementValue = sequence[middleIndex];

                if (middleElementValue <= element)
                {
                    startIndex = middleIndex;                                        
                }
                else if (middleElementValue > element)
                {
                    endIndex = middleIndex;
                }                
            }

            if (sequence[startIndex] == element)
            {
                return startIndex;
            }
            else
            {
                return -1;
            }
        }

        public static int BinarySearchRecursive(int[] sequence, int searchingElement, int startIndex, int endIndex)
        {
            if (startIndex + 1 == endIndex)
            {
                if (sequence[startIndex] == searchingElement)
                {
                    return startIndex;
                }
                else
                {
                    return -1;
                }
            }
           
            int middleIndex = ((startIndex + endIndex) >> 1);
            int middleElementValue = sequence[middleIndex];

            if (middleElementValue > searchingElement)
            {
                endIndex = middleIndex;
            }
            else
            {
                startIndex = middleIndex;
            }

            int result = BinarySearchRecursive(sequence, searchingElement, startIndex, endIndex);

            return result;
        }
    }
}
