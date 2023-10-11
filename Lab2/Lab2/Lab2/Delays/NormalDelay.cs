namespace Lab2.Delay;

public class NormalDelay : IDelay
{
    private readonly double _timeMean;

    private readonly double _timeDeviation;

    private readonly Random _random = new();

    public NormalDelay(double timeMean, double timeDeviation)
    {
        _timeMean = timeMean;
        _timeDeviation = timeDeviation;
    }

    public double Generate()
        => _timeMean + _timeDeviation * _random.NextDouble();
}