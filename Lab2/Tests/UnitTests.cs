using App;

namespace Tests;

public class UnitTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 2)]
    [InlineData(10, 14)]
    [InlineData(192, 169396)]
    [InlineData(438, 12300070)]
    [InlineData(1000, 1981471878)]
    public void PowersOfTwoSums_Solve(int input, long expected)
    {
        long result = PowersOfTwoSums.Solve(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0)]   // Out of range: number less than 1
    [InlineData(-1)]   // Out of range: number less than 1
    [InlineData(-112342)]   // Out of range: number less than 1
    [InlineData(1001)] // Out of range: number greater than 1000
    [InlineData(1234512345)]   // Out of range: number less than 1
    public void PowersOfTwoSums_Solve_ArgumentOutOfRangeException(int number)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PowersOfTwoSums.Solve(number));
    }
}