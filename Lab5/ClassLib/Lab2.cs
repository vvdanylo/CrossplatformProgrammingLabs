using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLib;

public class Lab2
{
    public static string Execute(string input)
    {
        Console.WriteLine("Running Lab2...");
        var number = 0;
        try
        {
            number = ReadNumberFromText(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while reading file: {ex.Message}");
            return "An error occured...";
        }

        var sum = 0;
        try
        {
            sum = Solve(number);
            Console.WriteLine($"The result is (The ways to represent the given number {number} as powers of 2): {sum}");
            return sum.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while solving the problem: {ex.Message}");
            return "An error occured...";
        }

    }

    private static int Solve(int number)
    {
        if (number < 1 || number > 1000)
        {
            throw new ArgumentOutOfRangeException("The number must be a natural number in the range from 1 to 1000");
        }

        var dp = new int[number + 1];
        dp[0] = 1;

        for (var i = 1L; i <= number; i++)
            dp[i] = (i % 2 == 1)
                ? dp[i - 1]
                : dp[i] = dp[i - 1] + dp[i / 2];

        var sums = dp[number];
        return sums;
    }

    private static int ReadNumberFromText(string text)
    {
        var lines = text.Replace("\r", "")
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new InvalidDataException("The file does not contain any text");
        }

        if (lines.Length != 1)
        {
            throw new InvalidDataException("The file must contain only one number");
        }

        if (!int.TryParse(lines[0], out var n))
        {
            throw new InvalidDataException("The file must contain an integer");
        }

        return n;
    }

    private static void WriteResultToFile(int result, string output)
    {
        File.WriteAllText(output, result.ToString());
    }
}
