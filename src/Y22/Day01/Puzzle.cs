using System.ComponentModel;

namespace Y22.Day01;

[Description("Day 1 - Calorie Counting")]
public class Puzzle : IPuzzleSolver
{
    public bool UseSampleData { get; set; }
    private const string SampleFile = @"Day01/Data/sample";
    private const string InputFile = @"Day01/Data/input";
    private string Data => File.ReadAllText(UseSampleData ? SampleFile : InputFile);

    [Description("Part 1 - Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?")]
    public string SolvePart1()
    {
        var result = CountCaloriesForTopN(1);
        return $"{result}";
    }

    [Description("Part 2 - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?")]
    public string SolvePart2()
    {
        var result = CountCaloriesForTopN(3);
        return $"{result}";
    }

    private int CountCaloriesForTopN(int elfCount)
    {
        if (elfCount <= 0)
        {
            return 0;
        }
        
        var sumOfCaloriesGroupedByElf = Data

            .Split($"{Environment.NewLine}{Environment.NewLine}",
                StringSplitOptions.RemoveEmptyEntries) // GroupCaloriesByElf

            .Select(elfCaloriesAsText =>
                elfCaloriesAsText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToList())
            .Select(calories => calories.Sum()); // GroupSumOfCaloriesByElf

        return elfCount == 1
            ? sumOfCaloriesGroupedByElf.Max()
            : sumOfCaloriesGroupedByElf.OrderByDescending(elfTotalCalories => elfTotalCalories).Take(elfCount).Sum();
    }
    
    public void PrintResults()
    {
        Console.WriteLine("Day 1: Calorie Counting");
        Console.WriteLine($"Part 1 - Find the Elf carrying the most Calories. How many total Calories is that Elf carrying? {SolvePart1()}");
        Console.WriteLine($"Part 2 - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?: {SolvePart2()}");
        Console.WriteLine();
    }
}