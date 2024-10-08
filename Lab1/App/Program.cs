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

        var result = ComputationalBiology.Solve(sequence, subsequence);
        
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
