namespace Aoc.Puzzles.Day01;

public static class Puzzle
{
    private const string InputFile = @"Day01/input";
    public static void PrintResults()
    {
        Console.WriteLine("Day-1 Puzzle");
        Console.WriteLine($"TotalCaloriesForTheElfWithMaxCalories: {TotalCaloriesForTheElfWithMaxCalories()}");
        Console.WriteLine($"TotalCaloriesForTheTop3ElfWithMaxCalories: {TotalCaloriesForTheTop3ElfWithMaxCalories()}");
    }

    private static long TotalCaloriesForTheElfWithMaxCalories() => File.ReadAllText(InputFile)
        .GroupCaloriesByElf()
        .GroupSumOfCaloriesByElf()
        .Max();

    private static long TotalCaloriesForTheTop3ElfWithMaxCalories() => File.ReadAllText(InputFile)
        .GroupCaloriesByElf()
        .GroupSumOfCaloriesByElf()
        .OrderByDescending(elfTotalCalories => elfTotalCalories)
        .Take(3)
        .Sum();

    private static IEnumerable<string> GroupCaloriesByElf(this string inputData) =>
        inputData.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);

    private static IEnumerable<long> GroupSumOfCaloriesByElf(this IEnumerable<string> inputData) => inputData
        .Select(elfCaloriesAsText =>
            elfCaloriesAsText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
                .ToList())
        .Select(calories => calories.Sum());
}