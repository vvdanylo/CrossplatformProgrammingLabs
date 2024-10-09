namespace App;

public class TrainRoute
{
    public int StationCount { get; set; }
    public List<(int StationNumber, int ArrivalTime)> Stations { get; set; }

    public TrainRoute()
    {
        Stations = new List<(int, int)>();
    }
}