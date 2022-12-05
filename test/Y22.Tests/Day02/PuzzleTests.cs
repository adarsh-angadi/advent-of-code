namespace Y22.Tests.Day02;

public class PuzzleTests
{
    [Theory]
    [InlineData(true, "15", "12")]
    [InlineData(false, "14531", "11258")]
    public void Day02_Test(bool useSampleData, string expectedSolutionPart1, string expectedSolutionPart2)
    {
        // Arrange
        var puzzle = new Y22.Day02.Puzzle
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