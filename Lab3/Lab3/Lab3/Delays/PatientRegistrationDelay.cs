using Lab3.Enums;
using Lab3.Items;

namespace Lab3.Delays;

public class PatientRegistrationDelay : IDelay
{
    private readonly IDelay _firstPatientTypeDelay = new ExponentialDelay(15);
    private readonly IDelay _secondPatientTypeDelay = new ExponentialDelay(40);
    private readonly IDelay _thirdPatientTypeDelay = new ExponentialDelay(30);
    
    public double Generate(SimpleItem item)
    {
        if (item is not Patient patient)
            return 0;

        var patientDelay = patient.Type switch
        {
            PatientType.ReadyForTreatment => _firstPatientTypeDelay,
            PatientType.UndergoPreliminaryExamination => _secondPatientTypeDelay,
            PatientType.JustGotToHospital => _thirdPatientTypeDelay,
            _ => throw new ArgumentOutOfRangeException()
        };

        return patientDelay.Generate(patient);
    }
}