using Lab3.Elements;

namespace Lab3.ModelStats;

public class BankModelStats : IModelStatsPrinter
{
    private NetMO _model;
    
    public BankModelStats(NetMO model)
    {
        _model = model;
    }
    
    public void PrintModelStats(double currentTime)
    {
        Console.WriteLine("Bank model statistics");
        Console.WriteLine($"Queue changes count: {SystemMO.QueueChangesCount}");

        var cashiers = _model.Elements.OfType<SystemMO>().ToList();
        
        double averageTimeBetweenCarDepartures = cashiers.Select(el => currentTime / el.ServedElementsQuantity).Sum();
        Console.WriteLine($"Average time between clients departures from windows: {averageTimeBetweenCarDepartures}");

        double totalClients = cashiers.Sum(c => c.ServedElementsQuantity + c.Failure);
        double failuresSum = cashiers.Sum(c => c.Failure);
        Console.WriteLine($"Failure rate = {failuresSum / totalClients * 100}");
    }
}