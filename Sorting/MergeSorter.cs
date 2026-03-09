using System;

namespace UniqueSort.Sorting
{
    // Sorts integers in ascending order using merge sort
    // Merge sort has O(n log n) time complexity and is a classic efficient algorithm
    public sealed class MergeSorter : INumberSorter
    {
        // Returns a sorted copy of the input array
        // The original input array is left unchanged

        public int[] Sort(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            int[] copy = CopyArray(numbers);

            if (copy.Length <= 1)
            {
                return copy;
            }

            int[] temp = new int[copy.Length];
            MergeSort(copy, temp, 0, copy.Length - 1);

            return copy;
        }

        // Recursively sorts the portion of the array between left and right
        private void MergeSort(int[] array, int[] temp, int left, int right)
        {
            // Base case: a range of size 0 or 1 is already sorted
            if (left >= right)
            {
                return;
            }

            int middle = left + (right - left) / 2;

            MergeSort(array, temp, left, middle);
            MergeSort(array, temp, middle + 1, right);

            Merge(array, temp, left, middle, right);
        }

        // Merges two already-sorted ranges (left..middle and middle+1..right)
        private void Merge(int[] array, int[] temp, int left, int middle, int right)
        {
            // Copy the relevant section into the temporary buffer
            for (int i = left; i <= right; i++)
            {
                temp[i] = array[i];
            }

            int leftIndex = left;
            int rightIndex = middle +1;
            int mergedIndex = left;

            // Compare the front of both halves and write the smaller value back to the array
            while (leftIndex <= middle && rightIndex <= right)
            {
                if (temp[leftIndex] <= temp[rightIndex])
                {
                    array[mergedIndex] = temp[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[mergedIndex] = temp[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            // Copy any remaining values from the left half
            // If the right half still has items, they are already in the correct place
            while (leftIndex <= middle)
            {
                array[mergedIndex] = temp[leftIndex];
                leftIndex++;
                mergedIndex++;
            }
        }

        // Creates a copy of the given array
        // We do this manually to keep the intent obvious and avoid mutating the caller's data
        private int[] CopyArray(int[] source)
        {
            int[] copy = new int[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                copy[i] = source[i];
            }

            return copy;
        }
    }
}