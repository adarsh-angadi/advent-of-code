using System.ComponentModel;

namespace Y22.Day02;

[Description("Day 2: Rock Paper Scissors")]
public class Puzzle : IPuzzleSolver
{
    public bool UseSampleData { get; set; }
    private const string SampleFile = @"Day02/Data/sample";
    private const string InputFile = @"Day02/Data/input";
    private string Data => File.ReadAllText(UseSampleData ? SampleFile : InputFile);

    [Description("Part 1 - What would your total score be if everything goes exactly according to your strategy guide?")]
    public string SolvePart1()
    {
        var scoreMap = new Dictionary<string, int>()
        {
            { "A X", 1 + 3 },
            { "B X", 1 + 0 },
            { "C X", 1 + 6 },
            { "A Y", 2 + 6 },
            { "B Y", 2 + 3 },
            { "C Y", 2 + 0 },
            { "A Z", 3 + 0 },
            { "B Z", 3 + 6 },
            { "C Z", 3 + 3 }
        };
        var result = CalculateScore(scoreMap);
        return $"{result}";
    }

    [Description("Part 2 - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?")]
    public string SolvePart2()
    {
        var scoreMap = new Dictionary<string, int>()
        {
            { "A X", 3 + 0 },
            { "B X", 1 + 0 },
            { "C X", 2 + 0 },
            { "A Y", 1 + 3 },
            { "B Y", 2 + 3 },
            { "C Y", 3 + 3 },
            { "A Z", 2 + 6 },
            { "B Z", 3 + 6 },
            { "C Z", 1 + 6 },
        };
        var result = CalculateScore(scoreMap);
        return $"{result}";
    }

    private int CalculateScore(IReadOnlyDictionary<string, int> scoreMap) => Data
        .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
        .Aggregate(0, (totalScore, play) => totalScore + scoreMap[play]);
    
    public void PrintResults()
    {
        Console.WriteLine("Day 2: Rock Paper Scissors");
        Console.WriteLine($"Part 1 - What would your total score be if everything goes exactly according to your strategy guide? {SolvePart1()}");
        Console.WriteLine($"Part 2 - What would your total score be if everything goes exactly according to your strategy guide? {SolvePart2()}");
        Console.WriteLine();
    }
}