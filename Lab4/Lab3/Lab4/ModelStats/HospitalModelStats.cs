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

        var endPatientsServing = (EndPatientsServing)_model.Elements.First(el => el.Name == "END_PATIENTS_SERVING");
        var averageSpentTimeByPatientType = endPatientsServing.ServedPatients
            .GroupBy(p => p.InitialType)
            .Select(group => (PatientType: group.Key, AverageSpentTime: group.Average(p => p.FinishServingTime - p.CreationTime)));

        Console.WriteLine("Average time spent by patient type in system");
        foreach (var patientTypeTime in averageSpentTimeByPatientType)
        {
            Console.WriteLine($"{patientTypeTime.PatientType}: {patientTypeTime.AverageSpentTime}");
        }
        
        var laboratoryRegister = (SystemMO)_model.Elements.First(el => el.Name == "LABORATORY_REGISTER");
        double averageTimeBetweenPatientsArrivalInLaboratory = currentTime /
                                                               (laboratoryRegister.ServedElementsQuantity +
                                                                laboratoryRegister.Queue.Items.Count);
        
        Console.WriteLine($"Average time between the arrival of patients in the laboratory: {averageTimeBetweenPatientsArrivalInLaboratory}");
        Console.WriteLine($"Patient type changes count: {NextElementAfterAnalysisPicker.PatientTypeChangesCount}");
        Console.WriteLine("------------------------");
    }
}