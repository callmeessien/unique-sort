using System;
using UniqueSort.Deduplication;
using UniqueSort.Formatting;
using UniqueSort.Parsing;
using UniqueSort.Sorting;
using UniqueSort.Services;

namespace UniqueSort.Tests
{
    public static class ManualTests
    {
        public static void Run()
        {
            UniqueSortService service = new UniqueSortService
            (
                new SplitIntegerParser(),
                new HashSetDuplicateRemover(),
                new MergeSorter(),
                new SpaceSeparatedFormatter()
            );

            RunTest(service, "Normal input", "5 8 2 10 6 3 8 2", "2 3 5 6 8 10");
            RunTest(service, "Negative numbers", "-1 -5 -3 -9 -6 -2 -1", "-9 -6 -5 -3 -2 -1");
            RunTest(service, "Empty input", "", "");
            RunTest(service, "Only spaces", "     ", "");
            RunTest(service, "Single number", "42", "42");
            RunTest(service, "All duplicates", "7 7 7 7 7", "7");
            RunTest(service, "Already sorted", "1 2 3 4 5", "1 2 3 4 5");
            RunTest(service, "Reverse sorted", "5 4 3 2 1", "1 2 3 4 5");
            RunTest(service, "Extra spaces", "5   2    5  1", "1 2 5");
        }

        private static void RunTest
        (
            UniqueSortService service, 
            string testName,
            string input,
            string expected
        )
        {
            string actual = service.Process(input);

            if (actual == expected)
            {
                Console.WriteLine($"PASS: {testName}");
            }
            else
            {
                Console.WriteLine($"FAIL: {testName}");
                Console.WriteLine($"Input: {input}");
                Console.WriteLine($"Expected: {expected}");
                Console.WriteLine($"Actual: {actual}");

            }
        }
    }
}