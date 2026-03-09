using System;
using UniqueSort.Deduplication;
using UniqueSort.Formatting;
using UniqueSort.Parsing;
using UniqueSort.Sorting;
using UniqueSort.Services;
using UniqueSort.Tests;

namespace UniqueSort
{
    // Application entry point. It handles startup and console interaction.
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Choose mode:");
            Console.WriteLine("1 - Run program");
            Console.WriteLine("2 - Run manual tests");

            string choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                RunApplication();
            }
            else if (choice == "2")
            {
                ManualTests.Run();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2");
            }
        }

        private static void RunApplication()
        {
            IIntegerParser parser = new SplitIntegerParser();
            IDuplicateRemover duplicateRemover = new HashSetDuplicateRemover();
            INumberSorter sorter = new MergeSorter();
            IOutputFormatter formatter = new SpaceSeparatedFormatter();

            UniqueSortService service = new UniqueSortService(parser, duplicateRemover, sorter, formatter);

            Console.WriteLine("Enter space-separated integers:");
            string input = Console.ReadLine() ?? string.Empty;

            try
            {
                string result = service.Process(input);
                Console.WriteLine(result);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: " + ex.Message);
            }
        }
    }
}