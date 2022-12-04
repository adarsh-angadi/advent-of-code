using System.Data.SqlTypes;

namespace Y22;

public interface IPuzzleSolver
{
    string SolvePart1();
    string SolvePart2();
    void PrintResults();

    bool UseSampleData 
    {
        get;
        set;
    }
}