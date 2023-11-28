using Lab3.Elements;
using Lab3.NextElement;

namespace Lab3.ModelStats;

public class HospitalModelStats : IModelStatsPrinter
{
    private readonly NetMO _model;
    
    public HospitalModelStats(NetMO model)
    {
        _model = model;
    }

    public void DoStatistics(double delta)
    {
        
    }
    
    public void PrintModelStats(double currentTime)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Hospital model statistics");
        
        var laboratoryRegister = (SystemMO)_model.Elements.First(el => el.Name == "LABORATORY_REGISTER");
        double averageTimeBetweenPatientsArrivalInLaboratory = currentTime /
                                                               (laboratoryRegister.ServedElementsQuantity +
                                                                laboratoryRegister.Queue.Items.Count);
        
        Console.WriteLine($"Average time between the arrival of patients in the laboratory: {averageTimeBetweenPatientsArrivalInLaboratory}");
        Console.WriteLine($"Patient type changes count: {NextElementAfterAnalysisPicker.PatientTypeChangesCount}");
        Console.WriteLine("------------------------");
    }
}