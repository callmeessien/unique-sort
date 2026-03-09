using System;
using UniqueSort.Deduplication;
using UniqueSort.Formatting;
using UniqueSort.Parsing;
using UniqueSort.Sorting;

namespace UniqueSort.Services
{
    // Coordinates the full processing pipeline: parse -> remove duplicates -> sort -> format
    // This class does not know the details of each algorithm.
    // It depends on abstractions (interfaces), which makes the design flexible and testable
    public sealed class UniqueSortService
    {
        private readonly IIntegerParser _parser;
        private readonly IDuplicateRemover _duplicateRemover;
        private readonly INumberSorter _sorter;
        private readonly IOutputFormatter _formatter;

        public UniqueSortService
        (
            IIntegerParser parser,
            IDuplicateRemover duplicateRemover,
            INumberSorter sorter,
            IOutputFormatter formatter
        )
        {
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
            _duplicateRemover = duplicateRemover ?? throw new ArgumentNullException(nameof(duplicateRemover));
            _sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        // Processes raw input text into the final formatted output
        public string Process(string rawInput)
        {
            int[] parsedNumbers = _parser.Parse(rawInput);
            int[] uniqueNumbers = _duplicateRemover.RemoveDuplicates(parsedNumbers);
            int[] sortedNumbers = _sorter.Sort(uniqueNumbers);

            return _formatter.Format(sortedNumbers);
        }
    }
}

