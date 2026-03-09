using System;

namespace UniqueSort.Deduplication
{
    // Removing duplicate integers
    public interface IDuplicateRemover
    {
        int[] RemoveDuplicates(int[] numbers);
    }
}