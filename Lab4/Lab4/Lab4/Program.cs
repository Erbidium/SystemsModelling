using Lab3;
using Lab3.ModelStats;

const int simulationTime = 10000;

var model = ModelCreator.CreateChainedModel(500);
model.Simulate(simulationTime);