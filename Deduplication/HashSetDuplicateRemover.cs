using System;
using System.Collections.Generic;

namespace UniqueSort.Deduplication
{
    // Returns only the first occurence of each number
    public sealed class HashSetDuplicateRemover : IDuplicateRemover
    {
        public int[] RemoveDuplicates(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            HashSet<int> seen = new HashSet<int>();
            List<int> uniqueNumbers = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                // HashSet.Add returns true only if the value was not already present
                if (seen.Add(numbers[i]))
                {
                    uniqueNumbers.Add(numbers[i]);
                }
            }

            int[] result = new int[uniqueNumbers.Count];

            for (int i = 0; i < uniqueNumbers.Count; i++)
            {
                result[i] = uniqueNumbers[i];
            }

            return result;
        }
    }
}