namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        string sequence = String.Empty;
        string subsequence = String.Empty;
        try
        {
            (sequence, subsequence) = FileDataHandler.ReadDnaSequencesFromFile();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while reading file: {ex.Message}");
            return;
        }

        var result = String.Empty;
        try
        {
            result = ComputationalBiology.Solve(sequence, subsequence);
            Console.WriteLine($"The result is (Does the genetic sequence {sequence} contain given subsequence {subsequence}?): {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while solving the problem: {ex.Message}");
            return;
        }

        try
        {
            FileDataHandler.WriteResultToFile(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while writing results to file: {ex.Message}");
            return;
        }

    }
}
