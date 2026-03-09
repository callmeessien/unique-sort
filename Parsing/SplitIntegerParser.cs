using System;

namespace UniqueSort.Parsing
{
    // Parses input by splitting on spaces and converting each token to an integer
    public sealed class SplitIntegerParser : IIntegerParser
    {
        // Converts a space-separated string into an integer array
        // Empty or whitespace-only input becomes an empty array
        public int[] Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new int[0];
            }

            // RemoveEmptyEntries ensures extra spaces do not create empty tokens
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                // TryParse gives us a clean validation point
                // If a token is not a valid integer, we throw a exception
                bool success = int.TryParse(parts[i], out numbers[i]);

                if (!success)
                {
                    throw new FormatException($"'{parts[i]}' is not a valid integer");
                }
            }

            return numbers;
        }
    }
}