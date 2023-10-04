namespace Lab1.Generators;

public static class StatsCalculator
{
    public static (double average, double variance) GetStats(List<double> numbersSequence)
    {
        double average = numbersSequence.Average();
        double variance = numbersSequence.Sum(number => Math.Pow(number - average, 2))
                          / (numbersSequence.Count - 1);

        return (average, variance);
    }
}