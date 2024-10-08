namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        var number = 0;
        try
        {
            number = FileDataHandler.ReadNumberFromFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while reading file: {ex.Message}");
            return;
        }

        var sum = 0;
        try
        {
            sum = PowersOfTwoSums.Solve(number);
            Console.WriteLine($"The result is (The ways to represent the given number {number} as powers of 2): {sum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while solving the problem: {ex.Message}");
            return;
        }

        try
        {
            FileDataHandler.WriteResultToFile(sum);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exeption occured while writing results to file: {ex.Message}");
            return;
        }

    }
}