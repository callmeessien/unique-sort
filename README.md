# UniqueSort

This is a C# console application that takes a space-separated list of integers, removes duplicates, sorts them in ascending order, and prints the result.

Built this as a learning project to practice clean code structure, interface-based design, and implementing algorithms without relying on LINQ or built-in sort methods.

---

## Features

- Parses space-separated integer input from the console
- Removes duplicate values using a `HashSet`
- Sorts using a hand-written merge sort implementation
- Formats and prints the result as a space-separated string
- Includes a manual test suite runnable from the console

---

## How It Works

The program runs a simple four-step pipeline:

```
Raw input string
    → Parse into integers
    → Remove duplicates
    → Sort ascending
    → Format and print
```

Each step is handled by a separate class, and each class implements an interface. The `UniqueSortService` ties them together, only knowing about the interfaces, not the concrete implementations.

### Step by step

**1. Parsing**  
`SplitIntegerParser` splits the input string on spaces using `StringSplitOptions.RemoveEmptyEntries`, which handles extra spaces cleanly. Each token is validated with `int.TryParse`. If any token is not a valid integer, a `FormatException` is thrown.

**2. Deduplication**  
`HashSetDuplicateRemover` iterates through the array and uses a `HashSet<int>` to track which values have already been seen. `HashSet.Add` returns `false` if the value already exists, so duplicates are skipped in a single pass. Time complexity: O(n).

**3. Sorting**  
`MergeSorter` implements merge sort from scratch. The array is recursively split in half, each half is sorted, then the two halves are merged back together in order. A temporary buffer array is used during the merge step. Time complexity: O(n log n). The original array is not mutated — a copy is made first.

**4. Formatting**  
`SpaceSeparatedFormatter` builds the output string using `StringBuilder`, placing a space between each number. Returns an empty string for empty input.

---

## Project Structure

```
UniqueSort/
├── Deduplication/
│   ├── IDuplicateRemover.cs
│   └── HashSetDuplicateRemover.cs
├── Formatting/
│   ├── IOutputFormatter.cs
│   └── SpaceSeparatedFormatter.cs
├── Parsing/
│   ├── IIntegerParser.cs
│   └── SplitIntegerParser.cs
├── Sorting/
│   ├── INumberSorter.cs
│   └── MergeSorter.cs
├── Services/
│   └── UniqueSortService.cs
├── Tests/
│   └── ManualTests.cs
└── Program.cs
```

Each folder represents one responsibility. The interface lives alongside its implementation, making it easy to see what contract a class fulfills.

---

## Key Design Decisions

**Interfaces for each component**  
Each processing step is defined by an interface (`IIntegerParser`, `IDuplicateRemover`, `INumberSorter`, `IOutputFormatter`). `UniqueSortService` depends on these interfaces rather than concrete classes. This keeps the service clean and makes it straightforward to swap in a different implementation, for example, a different sorting algorithm, without changing anything else.

**No LINQ**  
LINQ was intentionally avoided throughout. The goal was to understand and implement the underlying logic manually, which meant writing explicit loops, managing array indices, and building the merge sort algorithm by hand.

**Immutability in the sorter**  
`MergeSorter` copies the input array before sorting so the caller's data is never modified. This is a small but deliberate choice to avoid unexpected side effects.

**`UniqueSortService` as a coordinator**  
The service class does not contain any algorithm logic itself. It just calls each step in order and passes the result along. This keeps each piece small and focused.

---

## Example Input and Output

```
Input:  5 8 2 10 6 3 8 2
Output: 2 3 5 6 8 10
```

```
Input:  7 7 7 7 7
Output: 7
```

```
Input:  -1 -5 -3 -9 -6 -2 -1
Output: -9 -6 -5 -3 -2 -1
```

```
Input:  (empty)
Output: (empty)
```

---

## How to Run

**Requirements:** .NET 6 or later

```bash
git clone https://github.com/callmeessien/unique-sort.git
cd unique-sort
dotnet run
```

At startup, you will be prompted to choose a mode:

```
Choose mode:
1 - Run program
2 - Run manual tests
```

- Enter `1` to run the main program and provide your own input
- Enter `2` to run the built-in manual test suite

---

## Manual Tests

The project includes a `ManualTests` class that runs a set of predefined test cases and prints `PASS` or `FAIL` for each. No testing framework is used, just simple string comparison against expected output.

Test cases cover:

- Normal input with duplicates
- Negative numbers
- Empty input and whitespace-only input
- Single number
- All duplicates
- Already sorted and reverse sorted input
- Input with extra spaces between numbers

This approach keeps testing self-contained and runnable without any external dependencies.

---

## What I Practiced

- Structuring a C# project into folders by responsibility
- Defining and depending on interfaces rather than concrete classes
- Implementing merge sort manually, including the recursive split and merge steps
- Using `HashSet` for O(n) duplicate removal
- Input validation and error handling with `FormatException`

- Writing a basic manual test runner without a framework

