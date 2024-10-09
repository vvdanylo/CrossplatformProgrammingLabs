namespace App;

public class TrainRouteSolver
{
    static readonly int Infinity = int.MaxValue;
    public static int Solve(int startStation, int destinationStation, List<TrainRoute> trainRoutes)
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
}

