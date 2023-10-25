using Lab2;
using Lab2.Delays;
using Lab2.Elements;

const int simulationTime = 1000;

var createDelay = new ExponentialDelay(2);
var processDelay = new ExponentialDelay(1);

var create = new Create(createDelay) { Name = "CREATOR" };

var process1 = new Process(1, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
var process2 = new Process(1, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };
var process3 = new Process(1, processDelay) { Name = "PROCESSOR3", MaxQueue = 5 };

create.NextElement = process1;
process1.NextElement = process2;
process2.NextElement = process3;

var model = new Model(new (){ create, process1, process2, process3 });
model.Simulate(simulationTime);