namespace App;

public class ComputationalBiology
{
    private static readonly string Yes = "YES";
    private static readonly string No = "NO";
    public static string Solve(string? subsequence, string? sequence, bool verbose = false)
    {
        if (string.IsNullOrEmpty(subsequence) || string.IsNullOrEmpty(sequence))
        {
            throw new ArgumentException("The input string cannot be null or empty");
        }
        if (!(IsGeneticSequence(subsequence) && IsGeneticSequence(sequence)))
        {
            throw new ArgumentException("The input string is not a genetic sequence");
        }
        if (subsequence.Length > sequence.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(subsequence), "Subsequence can't be longer than sequence");
        }

        var j = 0;
        for (var i = 0; i < sequence.Length; i++)
        {
            if (char.ToUpper(subsequence[j]) == char.ToUpper(sequence[i])) j++;
            if (j == subsequence.Length) return Yes;
        }
        return No;
    }

    private static bool IsGeneticSequence(string sequence)
        => sequence.ToUpper().All(c => c == 'A' || c == 'G' || c == 'C' || c == 'T');
}

