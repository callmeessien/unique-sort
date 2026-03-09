using System;

namespace UniqueSort.Parsing
{
    // Converts raw text into integers
    public interface IIntegerParser
    {
        // Parses the input string into an array of integers
        int[] Parse(string input);
    }
}