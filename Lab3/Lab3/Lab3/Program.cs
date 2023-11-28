using Lab3;
using Lab3.ModelStats;

//const int bankSimulationTime = 1000;
//var model = ModelCreator.CreateHospitalModel();
//var statsPrinter = new BankModelStats(model);

const int hospitalSimulationTime = 100000;
var model = ModelCreator.CreateHospitalModel();
var statsPrinter = new HospitalModelStats(model);

model.Simulate(hospitalSimulationTime, statsPrinter);