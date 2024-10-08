namespace App;

public class PowersOfTwoSums
{
    public static int Solve(int number)
    {
        if (number < 1 || number > 1000)
        {
            throw new ArgumentOutOfRangeException("The number must be a natural number in the range from 1 to 1000");
        }

        var dp = new int[number + 1];
        dp[0] = 1;

        for (var i = 1L; i <= number; i++)
            dp[i] = (i % 2 == 1)
                ? dp[i - 1]
                : dp[i] = dp[i - 1] + dp[i / 2];

        var sums = dp[number];
        return sums;
    }
}
