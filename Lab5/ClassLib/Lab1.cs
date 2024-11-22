using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLib;

public class Lab1
{
    private static readonly string Yes = "YES";
    private static readonly string No = "NO";
    public static string Execute(string text)
    {
        Console.WriteLine("Running Lab1...");
        string sequence = String.Empty;
        string subsequence = String.Empty;
        try
        {
            (sequence, subsequence) = ReadDnaSequencesFromFile(text);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while reading file: {ex.Message}");
            return "An error occured...";
        }

        var result = String.Empty;
        try
        {
            result = Solve(sequence, subsequence);
            Console.WriteLine($"The result is (Does the genetic sequence {sequence} contain given subsequence {subsequence}?): {result}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while solving the problem: {ex.Message}");
            return "An error occured...";
        }
    }


    private static string Solve(string sequence, string subsequence)
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

    private static (string s, string t) ReadDnaSequencesFromFile(string text)
    {
        var lines = text.Replace("\r", "")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new Exception("No sequence in the provided file");
        }

        if (lines.Length != 2)
        {
            throw new Exception("File must contain only two rows");
        }

        var subsequence = lines[0];
        var sequence = lines[1];

        return (subsequence, sequence);
    }

    private static void WriteResultToFile(string result, string output)
    {
        File.WriteAllText(output, result);
    }

    private static bool IsGeneticSequence(string sequence)
    {
        return sequence.All(c => c == 'A' || c == 'C' || c == 'G' || c == 'T');
    }

}