namespace Lab1.Generators;

public class NumberSequenceGenerator
{
    private IGenerator _generator;

    public NumberSequenceGenerator(IGenerator generator)
    {
        _generator = generator;
    }
    
    public List<double> GenerateSequence(int numbersCount)
    {
        List<double> generatedNumbers = new();
        for (int i = 0; i < numbersCount; i++)
        {
            generatedNumbers.Add(_generator.GenerateNumber());
        }

        return generatedNumbers;
    }
}