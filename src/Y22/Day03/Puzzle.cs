using System.Collections.Immutable;
using System.ComponentModel;

namespace Y22.Day03;

[Description("Day 3: Rucksack Reorganization")]
public class Puzzle : IPuzzleSolver
{
    public bool UseSampleData { get; set; }
    private const string SampleFile = @"Day03/Data/sample";
    private const string InputFile = @"Day03/Data/input";
    private string Data => File.ReadAllText(UseSampleData ? SampleFile : InputFile);
    private IEnumerable<string> Rucksacks => Data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

    [Description("Part 1 - Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types?")]
    public string SolvePart1()
    {
        var result = Rucksacks
            .Select(rucksack => rucksack
                .Chunk(rucksack.Length / 2)
                .Select(compartments => compartments.ToImmutableHashSet())
                .Aggregate((firstCompartmentItems, secondCompartmentItems) =>
                    firstCompartmentItems.Intersect(secondCompartmentItems))
                .First())
            .Sum(CalculateScore);
        return $"{result}";
    }

    [Description("Part 2 - Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?")]
    public string SolvePart2()
    {
        const int elvGroupCount = 3;
        var result = Rucksacks
            .Select(rucksack => rucksack.ToImmutableHashSet())
            .Chunk(elvGroupCount)
            .Select(rucksackGroups => rucksackGroups.Aggregate((currentRucksackGroupItems, nextRucksackGroupItems) =>
                currentRucksackGroupItems.Intersect(nextRucksackGroupItems)).First())
            .Sum(CalculateScore);
        return $"{result}";
    }

    private static int CalculateScore(char character) => character % 32 + (char.IsUpper(character) ? 26 : 0);
    
    public void PrintResults()
    {
        Console.WriteLine("Day 3: Rucksack Reorganization");
        Console.WriteLine($"Part 1 - Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types? {SolvePart1()}");
        Console.WriteLine($"Part 2 - Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types? {SolvePart2()}");
        Console.WriteLine();
    }
}