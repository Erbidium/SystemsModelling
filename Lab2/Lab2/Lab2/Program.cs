using Lab2;

const int simulationTime = 1000;

var model = ModelCreator.GetThreeProcessesModelWithMultipleDevicesAndWeightedNextElements();
model.Simulate(simulationTime);