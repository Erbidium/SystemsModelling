using Lab3.Enums;
using Lab3.Items;

namespace Lab3.ItemFactories;

public class PatientFactory : IItemFactory
{
    private Random _rand = new();
    
    private List<(PatientType PatientType, double Chance)> _patientChances = new()
    {
        (PatientType.ReadyForTreatment, 0.5),
        (PatientType.UndergoPreliminaryExamination, 0.1),
        (PatientType.JustGotToHospital, 0.4)
    };
    
    public SimpleItem CreateItem()
    {
        var patientType = RandomHelper.GetWeightedRandomValue(_patientChances, _rand);

        return new Patient { Type = patientType };
    }
}