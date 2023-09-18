namespace Lab1.Generators;

public class FirstGenerator : IGenerator
{
    private double _lambda;

    private Random _random = new();
    
    public FirstGenerator(double lambda)
    {
        _lambda = lambda;
    }
    
    public double GenerateNumber()
    {
        return -1 / _lambda * Math.Log(_random.NextDouble());
    }
}