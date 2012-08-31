using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeSortAlgorithm
{
    class MergeSortAlgorithm
    {
        static void Main(string[] args)
        {
            int[] unsortedSequenceOfNumbers = 
            {
                5, 41, 13, 21, 15, 90, 5, 6, 34, 21, 12
            };

            int[] sortedSequence = MergeSortImplementation(unsortedSequenceOfNumbers);
                        
            Console.Write("Sorted sequence: ");
            foreach (int number in sortedSequence)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine();
        }

        public static int[] MergeSortImplementation(int[] unsortedSequence)
        {
            if (unsortedSequence.Length <= 1)
            {
                return unsortedSequence;
            }

            // Getting the length of the left part and the right part.
            int leftPartLength = unsortedSequence.Length / 2;
            int rightPartLength = unsortedSequence.Length - leftPartLength;

            int[] leftPart = new int[leftPartLength];
            int[] rightPart = new int[rightPartLength];

            // Save left half from the given sequence in the "leftPart".
            for (int i = 0; i < leftPartLength; i++)
            {
                leftPart[i] = unsortedSequence[i];
            }

            // Save right half from the given sequence in th "rightPart".
            for (int i = leftPartLength; i < unsortedSequence.Length; i++)
            {
                rightPart[i - leftPartLength] = unsortedSequence[i];
            }

            leftPart = MergeSortImplementation(leftPart);
            rightPart = MergeSortImplementation(rightPart);

            return Merging(leftPart, rightPart);
        }

        private static int[] Merging(int[] leftSequence, int[] rightSequence)
        {
            List<int> mergedSequence = new List<int>(leftSequence.Length + rightSequence.Length);
            int leftSequenceIndex = 0;
            int rightSequenceIndex = 0;

            while ((rightSequenceIndex < rightSequence.Length) || 
                   (leftSequenceIndex < leftSequence.Length))
            {
                if (leftSequenceIndex >= leftSequence.Length)
                {
                    mergedSequence.Add(rightSequence[rightSequenceIndex]);

                    if (rightSequenceIndex < rightSequence.Length)
                    {
                        rightSequenceIndex++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (rightSequenceIndex >= rightSequence.Length)
                {
                    mergedSequence.Add(leftSequence[leftSequenceIndex]);

                    if (leftSequenceIndex < leftSequence.Length)
                    {
                        leftSequenceIndex++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (leftSequence[leftSequenceIndex] <= rightSequence[rightSequenceIndex])
                {
                    mergedSequence.Add(leftSequence[leftSequenceIndex]);
                    leftSequenceIndex++;
                }
                else if (leftSequence[leftSequenceIndex] > rightSequence[rightSequenceIndex])
                {
                    mergedSequence.Add(rightSequence[rightSequenceIndex]);
                    rightSequenceIndex++;
                }
            } 

            return mergedSequence.ToArray();
        }
    }
}
