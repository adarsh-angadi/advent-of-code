using FluentAssertions;
using Xunit;

namespace Y22.Tests.Day01;

public class PuzzleTests
{
    [Theory]
    [InlineData(true, "24000", "45000")]
    [InlineData(false, "68467", "203420")]
    public void Day01_Test(bool useSampleData, string expectedSolutionPart1, string expectedSolutionPart2)
    {
        // Arrange
        var puzzle = new Y22.Day01.Puzzle
        {
            UseSampleData = useSampleData
        };

        // Act
        var solutionPart1 = puzzle.SolvePart1();
        var solutionPart2 = puzzle.SolvePart2();

        // Assert
        solutionPart1.Should().Be(expectedSolutionPart1);
        solutionPart2.Should().Be(expectedSolutionPart2);
    }
}