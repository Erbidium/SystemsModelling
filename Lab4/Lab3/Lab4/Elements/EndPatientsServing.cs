using Lab3.Delays;
using Lab3.Enums;
using Lab3.Items;

namespace Lab3.Elements;

public sealed class EndPatientsServing : Element
{
    public List<Patient> ServedPatients { get; } = new();

    public EndPatientsServing(IDelay delay) : base(delay)
    {
        TimeNext = double.MaxValue;
    }

    public override void Enter(SimpleItem item)
    {
        if (item is not Patient patient)
            return;
        
        patient.EndServing(TimeCurrent);
        ServedPatients.Add(patient);
        ServedElementsQuantity++;
    }

    public override void DoStatistics(double delta) { }
}