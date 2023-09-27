using ScottPlot;
using ScottPlot.Statistics;

namespace Lab1.Generators;

public static class HistogramCreator
{
    public static string SaveHistogramImage(List<double> numbersSequence, string generatorName)
    {
        double min = numbersSequence.Min();
        double max = numbersSequence.Max();
        
        const int intervalLength = 100;
        
        var plot = new Plot();
        var histogram = new Histogram(min, max, intervalLength);
        
        histogram.AddRange(numbersSequence);

        var bar = plot.AddBar(histogram.Counts, histogram.Bins);
        bar.BarWidth = (max - min) / histogram.BinCount;

        string plotFileName = $"Plot_{generatorName}_{numbersSequence.Count}.png";
        return plot.SaveFig(plotFileName);
    }
}