using System;

namespace UniqueSort.Formatting
{
    // Converts numbers into output text
    public interface IOutputFormatter
    {
        // Formats an integer array as a string
        string Format(int[] numbers);
    }
}