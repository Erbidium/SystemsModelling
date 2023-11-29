using Lab3;
using Lab3.ModelStats;

const int simulationTime = 10000;

//var model = ModelCreator.CreateChainedModel(100);
var model = ModelCreator.CreateBranchedModel(23, 4);
model.Simulate(simulationTime);