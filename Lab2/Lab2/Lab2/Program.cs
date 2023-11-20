using Lab2;
using Lab2.Delays;
using Lab2.Elements;
using Lab2.NextElement;

const int simulationTime = 1000;

var createDelay = new ExponentialDelay(2);
var processDelay = new ExponentialDelay(1);

var create = new Create(createDelay) { Name = "CREATOR" };

var process1 = new Process(1, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
var process2 = new Process(1, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };
var process3 = new Process(1, processDelay) { Name = "PROCESSOR3", MaxQueue = 5 };

//create.NextElement = new OneNextElement(process1);
//process1.NextElement = new OneNextElement(process2);
//process2.NextElement = new OneNextElement(process3);

create.NextElement = new WeightedNextElement
{
    NextElementChances = new() { (process1, 1) }
};

process1.NextElement = new WeightedNextElement
{
    NextElementChances = new() { (process2, 0.4), (process3, 0.6) }
};

process2.NextElement = new WeightedNextElement
{
    NextElementChances = new() { (process1, 0.3), (process3, 0.7) }
};

var model = new Model(new List<Element> { create, process1, process2, process3 });
model.Simulate(simulationTime);