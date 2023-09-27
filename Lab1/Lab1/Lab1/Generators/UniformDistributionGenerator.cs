namespace Lab1.Generators;

public class UniformDistributionGenerator : IGenerator
{
    private double _z0 = 3;

    private const double A = 5e13;

    private const double C = 2e31;

    private double _currentZ;

    public UniformDistributionGenerator()
    {
        _currentZ = _z0;
    }
    
    public double GenerateNumber()
    {
        return A * (_currentZ % C) / C;
    }

    public double GetDistributionLawProbability(double value)
    {
        return value switch
        {
            < 0 => 0,
            >= 1 => 1,
            _ => value
        };
    }
}