namespace Y22.Tests.Day03;

public class PuzzleTests
{
    [Theory]
    [InlineData(true, "157", "70")]
    [InlineData(false, "8243", "2631")]
    public void Day03_Test(bool useSampleData, string expectedSolutionPart1, string expectedSolutionPart2)
    {
        // Arrange
        var puzzle = new Y22.Day03.Puzzle
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