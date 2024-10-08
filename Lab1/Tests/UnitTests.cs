using App;

namespace Tests;


public class UnitTests
{
    [Theory]
    [InlineData("GTA", "AGCTA", "YES")]
    [InlineData("AAAG", "GAAAAAT", "NO")]
    [InlineData("ACGT", "ACGT", "YES")]
    [InlineData("AC", "AGT", "NO")]
    [InlineData("ACGT", "CCGACTAAGAAGCCAGT", "YES")]
    public void ComputationalBiology_CanSolve(string sequence, string subsequence, string expected)
    {
        var result = ComputationalBiology.Solve(sequence, subsequence);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "ACGT")]
    [InlineData("GATGTAAG", "")]
    [InlineData("", "")]
    [InlineData("\r", "\r")]
    [InlineData("\n", "\t")]
    [InlineData("ABCD", "AKSDADDG")]
    [InlineData("QWRETY", "QWERTY")]
    public void ComputationalBiology_ThrowsArgumentException(string sequence, string subsequence)
    {
        Assert.Throws<ArgumentException>(() => ComputationalBiology.Solve(sequence, subsequence));
    }

    [Theory]
    [InlineData("CCGACTAAGAAGCCAGT", "ACGT")]
    [InlineData("CAGT", "AT")]
    public void ComputationalBiology_ThrowsArgumentOutOfRangeException(string sequence, string subsequence)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ComputationalBiology.Solve(sequence, subsequence));

    }
}

