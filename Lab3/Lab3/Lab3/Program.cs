using Lab3;

const int simulationTime = 1000;

var model = ModelCreator.GetTwoProcessModelWithPriorities();
model.Simulate(simulationTime);