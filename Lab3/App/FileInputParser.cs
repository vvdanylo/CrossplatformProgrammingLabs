namespace App;

public class FileInputParser
{
    public static List<TrainRoute> ParseRouteString(string routeString, out int startStation, out int destinationStation)
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
}
