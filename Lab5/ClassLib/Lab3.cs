using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib;

public class Lab3
{
    static readonly int Infinity = int.MaxValue;

    public static string Execute(string input, string output)
    {
        Console.WriteLine("Running Lab3...");
        int startStation = 0;
        int destinationStation = 0;
        List<TrainRoute> trainRoutes;

        try
        {
            (startStation, destinationStation, trainRoutes) = ReadInputFromFile(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while reading the file: {ex.Message}");
            return "An error occured...";
        }

        int result;
        try
        {
            result = Solve(startStation, destinationStation, trainRoutes);
            if (result == -1)
            {
                Console.WriteLine($"There is no route from station 1 to station {destinationStation}.");
            }
            else
            {
                Console.WriteLine($"The shortest time to reach station {destinationStation} is: {result}");
            }
            return result.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while solving the problem: {ex.Message}");
            return "An error occured...";
        }
    }

    private static int Solve(int startStation, int destinationStation, List<TrainRoute> trainRoutes)
    {
        var schedule = new List<List<(int timeStart, int timeEnd, int destination)>>(startStation + 1);

        for (int i = 0; i <= startStation; i++)
        {
            schedule.Add(new List<(int, int, int)>());
        }

        foreach (var route in trainRoutes)
        {
            int previousStation = route.Stations[0].StationNumber;
            int previousTime = route.Stations[0].ArrivalTime;

            for (int j = 1; j < route.StationCount; j++)
            {
                int currentStation = route.Stations[j].StationNumber;
                int currentTime = route.Stations[j].ArrivalTime;

                schedule[previousStation].Add((previousTime, currentTime, currentStation));
                previousStation = currentStation;
                previousTime = currentTime;
            }
        }

        var minTime = Enumerable.Repeat(Infinity, startStation + 1).ToList();
        minTime[1] = 0;

        var isFinal = new List<bool>(new bool[startStation + 1]);

        while (true)
        {
            int minStation = -1;
            int currentMinTime = Infinity;

            for (int i = 1; i <= startStation; i++)
            {
                if (!isFinal[i] && minTime[i] < currentMinTime)
                {
                    currentMinTime = minTime[i];
                    minStation = i;
                }
            }

            if (currentMinTime == Infinity) break;
            isFinal[minStation] = true;

            foreach (var edge in schedule[minStation])
            {
                if (edge.timeStart >= minTime[minStation] && edge.timeEnd < minTime[edge.destination])
                {
                    minTime[edge.destination] = edge.timeEnd;
                }
            }
        }

        return minTime[destinationStation] == Infinity ? -1 : minTime[destinationStation]; // Return -1 if unreachable
    }
    private static List<TrainRoute> ParseRouteString(string routeString, out int startStation, out int destinationStation)
    {
        var lines = routeString.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var firstLine = lines[0].Split();

        if (firstLine.Length < 2 ||
            !int.TryParse(firstLine[0], out startStation) ||
            !int.TryParse(firstLine[1], out destinationStation))
        {
            throw new InvalidDataException("The first line must contain two integers: startStation and destinationStation.");
        }

        int routeCount = int.Parse(lines[1]);
        var trainRoutes = new List<TrainRoute>();

        for (int i = 0; i < routeCount; i++)
        {
            var routeData = lines[i + 2].Split();
            int stationCount = int.Parse(routeData[0]);

            var route = new TrainRoute { StationCount = stationCount };
            for (int j = 0; j < stationCount; j++)
            {
                int stationNumber = int.Parse(routeData[2 * j + 1]);
                int arrivalTime = int.Parse(routeData[2 * j + 2]);
                route.Stations.Add((stationNumber, arrivalTime));
            }

            trainRoutes.Add(route);
        }

        return trainRoutes;
    }
    private static (int startStation, int destinationStation, List<TrainRoute> trainRoutes) ReadInputFromFile(string input)
    {
        if (!File.Exists(input))
        {
            throw new FileNotFoundException($"The file {input} was not found.");
        }

        var lines = File.ReadAllLines(input)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length < 2)
        {
            throw new InvalidDataException("The file must contain at least two lines of input.");
        }

        string[] firstLine = lines[0].Split();
        if (firstLine.Length != 2 ||
            !int.TryParse(firstLine[0], out var startStation) ||
            !int.TryParse(firstLine[1], out var destinationStation))
        {
            throw new InvalidDataException("The first line must contain two integers: Start Station and Destination Station.");
        }

        if (!int.TryParse(lines[1], out var routesCount))
        {
            throw new InvalidDataException("The second line must contain an integer Routes Count.");
        }

        List<TrainRoute> trainRoutes = new List<TrainRoute>();

        for (int i = 0; i < routesCount; i++)
        {
            if (i + 2 >= lines.Length)
            {
                break;
            }

            string[] routeData = lines[i + 2].Split();
            int K = int.Parse(routeData[0]);

            TrainRoute route = new TrainRoute { StationCount = K };

            for (int j = 0; j < K; j++)
            {
                int stationNumber = int.Parse(routeData[2 * j + 1]);
                int arrivalTime = int.Parse(routeData[2 * j + 2]);
                route.Stations.Add((stationNumber, arrivalTime));
            }

            trainRoutes.Add(route);
        }

        return (startStation, destinationStation, trainRoutes);
    }

    public static void WriteResultToFile(int result, string output)
    {
        File.WriteAllText(output, result.ToString());
    }

    private class TrainRoute
    {
        public int StationCount { get; set; }
        public List<(int StationNumber, int ArrivalTime)> Stations { get; set; }

        public TrainRoute()
        {
            Stations = new List<(int, int)>();
        }
    }
}
