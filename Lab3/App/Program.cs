namespace App;

public class Program
{
    public static void Main(string[] args)
    {
        int startStation = 0;
        int destinationStation = 0;
        List<TrainRoute> trainRoutes;

        try
        {
            (startStation, destinationStation, trainRoutes) = FileDataHandler.ReadInputFromFile();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while reading the file: {ex.Message}");
            return;
        }

        int result;
        try
        {
            result = TrainRouteSolver.Solve(startStation, destinationStation, trainRoutes);
            if (result == -1)
            {
                Console.WriteLine($"There is no route from station 1 to station {destinationStation}.");
            }
            else
            {
                Console.WriteLine($"The shortest time to reach station {destinationStation} is: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while solving the problem: {ex.Message}");
            return;
        }

        try
        {
            FileDataHandler.WriteResultToFile(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while writing results to file: {ex.Message}");
            return;
        }
    }
}
