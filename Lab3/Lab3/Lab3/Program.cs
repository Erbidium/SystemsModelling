using Lab3;
using Lab3.ModelStats;

const int simulationTime = 1000;

var model = ModelCreator.GetTwoProcessModelWithPriorities();

var statsPrinter = new BankModelStats(model);

model.Simulate(simulationTime, statsPrinter);