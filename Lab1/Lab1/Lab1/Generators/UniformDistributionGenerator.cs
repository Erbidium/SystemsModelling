namespace Lab1.Generators;

public class UniformDistributionGenerator : IGenerator
{
    private double _z0 = new Random().NextDouble();

    private double _a = Math.Pow(5, 13);

    private double _c = Math.Pow(2, 31);

    private double _currentZ;

    public UniformDistributionGenerator()
        => _currentZ = _z0;
    
    public double GenerateNumber()
    {
        _currentZ = _a * _currentZ % _c;
        return _currentZ / _c;
    }

    public double GetDistributionLawProbability(double value)
        => value switch
        {
            < 0 => 0,
            >= 1 => 1,
            _ => value
        };
}