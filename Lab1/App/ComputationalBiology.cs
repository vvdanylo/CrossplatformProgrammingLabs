namespace App;

public class ComputationalBiology
{
    private static readonly string Yes = "YES";
    private static readonly string No = "NO";
    public static string Solve(string sequence, string subsequence)
    {
        if (string.IsNullOrEmpty(subsequence) || string.IsNullOrEmpty(sequence))
        {
            throw new ArgumentException("The input string cannot be null or empty");
        }
        if (!(IsGeneticSequence(subsequence) && IsGeneticSequence(sequence)))
        {
            throw new ArgumentException("The input string is not a genetic sequence");
        }
        if (subsequence.Length < sequence.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(subsequence), "Subsequence can't be longer than sequence");
        }

        var j = 0;
        for (var i = 0; i < subsequence.Length; i++)
        {
            if (char.ToUpper(sequence[j]) == char.ToUpper(subsequence[i])) j++;
            if (j == sequence.Length) return Yes;
        }
        return No;
    }

    private static bool IsGeneticSequence(string sequence)
    {
        return sequence.All(c => c == 'A' || c == 'C' || c == 'G' || c == 'T');
    }

}

