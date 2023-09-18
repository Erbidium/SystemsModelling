namespace Lab1.Generators;

public class NormalDistributionGenerator : IGenerator
{
    private double _sigma;

    private double _a;
    
    private Random _random = new();

    public NormalDistributionGenerator(double sigma, double a)
    {
        _sigma = sigma;
        _a = a;
    }
    public double GenerateNumber()
    {
        return _sigma * GenerateMu() + _a;
    }

    private double GenerateMu()
    {
        double sum = 0;
        
        for (int i = 0; i < 12; i++)
        {
            sum += _random.NextDouble();
        }

        return sum - 6;
    }
}