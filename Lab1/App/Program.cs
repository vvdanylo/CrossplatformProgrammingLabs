namespace App;

public class Program
{
    public static void Main(string[] args)
    {

        try
        {
            var verbose = args.Length == 1 && args[0].Equals("--verbose") ? true : false;
            solve(verbose);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void solve(bool verbose)
    {
        Console.WriteLine("Enter subsequence to find:");
        var subsequence = Console.ReadLine();
        Console.WriteLine("Enter sequence where to look for subsequence:");
        var sequence = Console.ReadLine();

        var result = ComputationalBiology.Solve(subsequence, sequence, verbose);
        Console.WriteLine(result);

    }
}
