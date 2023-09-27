namespace Lab1.Generators;

public static class StatsCalculator
{
    public static (double average, double variance)GetStats(List<double> numbers)
    {
        double average = numbers.Average();
        double variance = numbers.Sum(number => Math.Pow(number - average, 2))
                          / (numbers.Count - 1);

        return (average, variance);
    }
}