namespace Lab2.Delays;

public class UniformDelay : IDelay
{
    private readonly double _timeMin;

    private readonly double _timeMax;

    private readonly Random _random = new();

    public UniformDelay(double timeMin, double timeMax)
    {
        _timeMin = timeMin;
        _timeMax = timeMax;
    }
    
    public double Generate()
    {
        double randomNumber = 0;
        while (randomNumber == 0)
            randomNumber = _random.NextDouble();
        
        return _timeMin + randomNumber * (_timeMax - _timeMin);
    }
}