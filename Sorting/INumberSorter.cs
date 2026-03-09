using System;

namespace UniqueSort.Sorting
{
    // Sorting Integers
    public interface INumberSorter
    {
        // Returns a sorted copy of the input numbers
        int[] Sort(int[] numbers);
    }
}