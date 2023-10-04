namespace Lab1.Generators;

public static class ConfidenceChance
{
    public static double FindAverageForGenerator
    (
        IGenerator generator,
        int numberOfDistributionLawParameters,
        int intervalsCount,
        int generatedNumbersCount,
        int testRunsCount
    )
    {
        double averageConfidenceChanceSum = 0;
        
        for (int i = 0; i < testRunsCount; i++)
        {
            var numberSequenceGenerator = new NumberSequenceGenerator(generator);
            var numbersSequence = numberSequenceGenerator.GenerateSequence(generatedNumbersCount);
            averageConfidenceChanceSum += DistributionTest.ChiSquaredTest(numbersSequence, generator, numberOfDistributionLawParameters, intervalsCount);
        }

        return Math.Round(averageConfidenceChanceSum / testRunsCount, 2);
    }
}