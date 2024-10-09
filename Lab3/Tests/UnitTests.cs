using App;

namespace Tests;

public class UnitTests
{
    public static IEnumerable<object[]> TrainRouteTestData()
    {
        yield return new object[]
        {
            """
            5 3
            4
            2 1 5 2 10
            2 2 10 4 15
            4 5 0 4 17 3 20 2 35
            3 1 2 3 40 4 45
            """,
            20
        };

        yield return new object[]
        {
            """
            5 2
            2
            4 1 1 3 2 4 10 5 20
            3 5 10 4 15 2 40
            """,
            40
        };

        yield return new object[]
        {
            """
            10 2
            3
            6 10 10 9 14 8 15 6 20 5 21 2 30
            4 1 0 4 10 7 15 9 20
            4 3 9 4 11 7 13 9 14
            """,
            30
        };

        yield return new object[]
        {
            """
            10 10
            2
            5 1 0 3 11 6 23 7 27 8 30
            5 4 20 5 22 6 24 7 26 10 35
            """,
            35
        };

        yield return new object[]
        {
            """
            10 2
            2
            3 1 0 4 5 8 11
            7 10 4 9 5 8 10 5 15 3 21 2 49 1 52
            """,
            -1
        };
    }

    [Theory]
    [MemberData(nameof(TrainRouteTestData))]
    public void TrainRouteSolver_CanSolve(string routeString, int expectedResult)
    {
        var trainRoutes = FileInputParser.ParseRouteString(routeString, out int startStation, out int destinationStation);
        int result = TrainRouteSolver.Solve(startStation, destinationStation, trainRoutes);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0, 3)]
    [InlineData(1, 6)]
    [InlineData(-1, -1)]
    public void TrainRouteSolver_ThrowsArgumentOutOfRangeException(int startStation, int destinationStation)
    {
        var routes = new List<TrainRoute>();
        Assert.Throws<ArgumentOutOfRangeException>(() => TrainRouteSolver.Solve(startStation, destinationStation, routes));
    }
}
