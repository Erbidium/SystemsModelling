using Lab3;
using Lab3.ModelStats;

const int simulationTime = 1000;

//var model = ModelCreator.CreateHospitalModel();
//var statsPrinter = new BankModelStats(model);

var model = ModelCreator.CreateHospitalModel();
var statsPrinter = new HospitalModelStats(model);

model.Simulate(simulationTime, statsPrinter);