namespace Lab1.Generators;

public class ExponentialDistributionGenerator : IGenerator
{
    private double _lambda;

    private Random _random = new();
    
    public ExponentialDistributionGenerator(double lambda)
    {
        _lambda = lambda;
    }
    
    public double GenerateNumber()
    {
        return -1 / _lambda * Math.Log(_random.NextDouble());
    }
}