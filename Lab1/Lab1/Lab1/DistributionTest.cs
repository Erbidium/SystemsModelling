using Lab1.Generators;
using MathNet.Numerics.Distributions;

namespace Lab1;

public static class DistributionTest
{
    public static void ChiSquaredTest(List<double> numbersSequence, IGenerator generator, int numberOfDistributionLawParameters, int intervalsCount)
    {
        double min = numbersSequence.Min();
        double max = numbersSequence.Max();
        
        double intervalWidth = (max - min) / intervalsCount;

        int[] intervals = CreateIntervals();

        var mergedIntervals = MergeIntervals(intervals, 5);

        double x2 = GetChiSquared();

        Console.WriteLine($"Intervals count: {mergedIntervals.Count}");
        Console.WriteLine($"X2: {x2}");

        int degreesOfFreedom = mergedIntervals.Count - 1 - numberOfDistributionLawParameters;

        const double alpha = 0.05;
        
        double tableChiSquared =  new ChiSquared(degreesOfFreedom).InverseCumulativeDistribution(alpha);

        Console.WriteLine($"Table X2: {tableChiSquared},  confidence chance: {1 - alpha}");

        int[] CreateIntervals()
        {
            int[] createdIntervals = new int[intervalsCount];
            
            foreach (var number in numbersSequence)
            {
                int interval = (int)((number - min) / intervalWidth);
                createdIntervals[number == max ? interval - 1 : interval]++;
            }

            return createdIntervals;
        }
        
        static List<(int startIntervalIndex, int endIntervalIndex, int intervalCount)> MergeIntervals(int[] intervals, int minIntervalCount)
        {
            List<(int startIntervalIndex, int endIntervalIndex, int intervalCount)> mergedIntervals = new();
        
            int startIntervalIndex = 0;
            int currentIntervalCount = 0;
        
            for (int i = 0; i < intervals.Length; i++)
            {
                currentIntervalCount += intervals[i];

                if (currentIntervalCount < minIntervalCount)
                    continue;
            
                mergedIntervals.Add((startIntervalIndex, i + 1, currentIntervalCount));

                startIntervalIndex = i + 1;
                currentIntervalCount = 0;
            }
        
            if (currentIntervalCount != 0)
                mergedIntervals.Add((startIntervalIndex, intervals.Length, currentIntervalCount));

            return mergedIntervals;
        }

        double GetChiSquared()
        {
            double chiSquaredValue = 0;
            for (int i = 0; i < mergedIntervals.Count; i++)
            {
                double upperIntervalLimit = min + mergedIntervals[i].endIntervalIndex * intervalWidth;
                double upperIntervalLimitProbability = generator.GetDistributionLawProbability(upperIntervalLimit);
                
                double lowerIntervalLimit = min + mergedIntervals[i].startIntervalIndex * intervalWidth;
                double lowerIntervalLimitProbability = generator.GetDistributionLawProbability(lowerIntervalLimit);

                double theoreticalProbability = upperIntervalLimitProbability - lowerIntervalLimitProbability;
                double expectedHitsNumber = numbersSequence.Count * theoreticalProbability;

                chiSquaredValue += Math.Pow(mergedIntervals[i].intervalCount - expectedHitsNumber, 2) / expectedHitsNumber;
            }

            return chiSquaredValue;
        }
    }
}