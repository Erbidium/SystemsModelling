using Lab2;
using Lab2.Delay;
using Lab2.Elements;

var createDelay = new ExponentialDelay(2);
var processDelay = new ExponentialDelay(1);

var process = new Process(processDelay)
{
    Name = "PROCESSOR",
    MaxQueue = 5
};

var create = new Create(createDelay)
{
    Name = "CREATOR",
    NextElement = process
};

Console.WriteLine($"Id0 = {create.Id}  Id1 = {process.Id}");

var elements = new List<Element>{ create, process };

var model = new Model(elements);
model.Simulate(1000);