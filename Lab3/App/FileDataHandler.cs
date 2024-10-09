namespace App;

public class FileDataHandler
{
    private static readonly string FolderPath = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
    private const string OutputFileName = "OUTPUT.TXT";
    private const string InputFileName = "INPUT.TXT";
    private static readonly string InputFilePath = Path.Combine(FolderPath, InputFileName);
    private static readonly string OutputFilePath = Path.Combine(FolderPath, OutputFileName);

    public static (int startStation, int destinationStation, List<TrainRoute> trainRoutes) ReadInputFromFile()
    {
        if (!File.Exists(InputFilePath))
        {
            throw new FileNotFoundException($"The file {InputFileName} was not found.");
        }

        var lines = File.ReadAllLines(InputFilePath)
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

    public static void WriteResultToFile(int result)
    {
        File.WriteAllText(OutputFilePath, result.ToString());
    }
}
