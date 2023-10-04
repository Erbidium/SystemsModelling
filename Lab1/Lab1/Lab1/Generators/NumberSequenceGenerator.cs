namespace Lab1.Generators;

public class NumberSequenceGenerator
{
    public IGenerator Generator { get; }

    public NumberSequenceGenerator(IGenerator generator)
        => Generator = generator;
    
    public List<double> GenerateSequence(int numbersCount)
    {
        List<double> generatedNumbers = new();
        for (int i = 0; i < numbersCount; i++)
        {
            generatedNumbers.Add(Generator.GenerateNumber());
        }

        return generatedNumbers;
    }
}