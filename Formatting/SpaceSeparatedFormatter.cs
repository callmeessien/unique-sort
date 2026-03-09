using System;
using System.Text;

namespace UniqueSort.Formatting
{
    // Formats integers as one space-separated string (Example: [2, 3, 5] -> "2 3 5")
    public sealed class SpaceSeparatedFormatter : IOutputFormatter
    {
        // Converts the array into a space-separated
        public string Format(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(' ');
                }

                builder.Append(numbers[i]);
            }

            return builder.ToString();
        } 
    }
}