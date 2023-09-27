using Lab1.Generators;

const int generatedNumbersCount = 10000;

// var generator = new ExponentialDistributionGenerator(1);
var generator = new NormalDistributionGenerator(0.5, 0.1);
// var generator = new UniformDistributionGenerator();

var numberSequenceGenerator = new NumberSequenceGenerator(generator);

var plotPath = HistogramCreator.SaveHistogramImage(numberSequenceGenerator, generatedNumbersCount);
Console.WriteLine(plotPath);

var (average, variance) = StatsCalculator.GetStats(numberSequenceGenerator.GenerateSequence(10000));
Console.WriteLine($"Average: {average}");
Console.WriteLine($"Variance: {variance}");
