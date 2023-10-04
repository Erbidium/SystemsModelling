using Lab1;
using Lab1.Generators;

const int generatedNumbersCount = 10000;

//var generator = new ExponentialDistributionGenerator(100); // parameters 1
var generator = new NormalDistributionGenerator(0.5, 0.1); // parameters 2
//var generator = new UniformDistributionGenerator(); // parameters 2

var numberSequenceGenerator = new NumberSequenceGenerator(generator);
var numbersSequence = numberSequenceGenerator.GenerateSequence(generatedNumbersCount);

var plotPath = HistogramCreator.SaveHistogramImage(numbersSequence, numberSequenceGenerator.Generator.GetType().Name);
Console.WriteLine($"Plot path: {plotPath}");

var (average, variance) = StatsCalculator.GetStats(numbersSequence);
Console.WriteLine("Generator stats:");
Console.WriteLine($"Average: {average}");
Console.WriteLine($"Variance: {variance}");

const int testRunsCount = 100;
const int intervalsCount = 100;
double averageConfidenceChance =
    ConfidenceChance.FindAverageForGenerator(generator, 2, intervalsCount, generatedNumbersCount, testRunsCount);

Console.WriteLine($"Average confidence chance: {averageConfidenceChance}");


