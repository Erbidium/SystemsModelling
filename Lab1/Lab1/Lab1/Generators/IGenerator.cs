namespace Lab1.Generators;

public interface IGenerator
{
    double GenerateNumber();

    double GetDistributionLawProbability(double value);
}