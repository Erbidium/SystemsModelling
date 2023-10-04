using Lab1;
using Lab1.Generators;

const int generatedNumbersCount = 10000;

//var generator = new ExponentialDistributionGenerator(100); // 1
var generator = new NormalDistributionGenerator(0.5, 0.1); // 2
//var generator = new UniformDistributionGenerator(); // 2

var numberSequenceGenerator = new NumberSequenceGenerator(generator);
var numbersSequence = numberSequenceGenerator.GenerateSequence(generatedNumbersCount);

var plotPath = HistogramCreator.SaveHistogramImage(numbersSequence, numberSequenceGenerator.Generator.GetType().Name);
Console.WriteLine(plotPath);

var (average, variance) = StatsCalculator.GetStats(numberSequenceGenerator.GenerateSequence(10000));
Console.WriteLine($"Average: {average}");
Console.WriteLine($"Variance: {variance}");

DistributionTest.ChiSquaredTest(numbersSequence, generator, 2, 100);