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

    }
}