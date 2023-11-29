using Lab3.Enums;

namespace Lab3.Items;

public class Patient : SimpleItem
{
    public PatientType InitialType { get; init; }
    
    public PatientType Type { get; set; }

    public double CreationTime { get; }

    public double FinishServingTime { get; private set; }

    public Patient(double currentTime, PatientType type)
    {
        CreationTime = currentTime;
        
        InitialType = type;
        Type = type;
    }

    public void EndServing(double currentTime)
    {
        FinishServingTime = currentTime;
    }
}