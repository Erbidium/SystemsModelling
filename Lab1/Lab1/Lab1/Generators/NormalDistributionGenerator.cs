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
    
    public double GetDistributionLawProbability(double value)
    {
        return 0.5 * (1 + Erf((value - _a) / (_sigma * Math.Sqrt(2))));
    }

    private static double Erf(double value)
    {
        double a1 = 0.254829592;
        double a2 = -0.284496736;
        double a3 = 1.421413741;
        double a4 = -1.453152027;
        double a5 = 1.061405429;
        double p = 0.3275911;
        
        int sign = 1;
        if (value < 0)
            sign = -1;
        value = Math.Abs(value);
        
        double t = 1.0 / (1.0 + p * value);
        double y = 1.0 - ((((a5 * t + a4) * t + a3) * t + a2) * t + a1) * t * Math.Exp(-value * value);
 
        return sign * y;
    }
}