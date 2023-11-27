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

        int processedCount = _model.Elements.Count(el => el is SystemMO);
        int totalServedCount = _model.Elements.Where(el => el is SystemMO).Select(el => el.ServedElementsQuantity).Sum();

        double averageTimeBetweenCarDepartures = processedCount * currentTime / totalServedCount;
        Console.WriteLine($"Average time between clients departures from windows: {averageTimeBetweenCarDepartures}");
    }
}