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
            var chiSquaredTest = DistributionTest.ChiSquaredTest(numbersSequence, generator, numberOfDistributionLawParameters, intervalsCount);

            averageConfidenceChanceSum += chiSquaredTest.ConfidenceChance;
            
            Console.WriteLine($"Test number: {i + 1}");
            Console.WriteLine($"Intervals count: {chiSquaredTest.IntervalsCount}");
            Console.WriteLine($"X2: {chiSquaredTest.CalculatedChiSquared}");
            Console.WriteLine($"Table X2: {chiSquaredTest.TableChiSquared},  confidence chance: {chiSquaredTest.ConfidenceChance}");
            Console.WriteLine("_______________________");
        }

        return Math.Round(averageConfidenceChanceSum / testRunsCount, 2);
    }
}