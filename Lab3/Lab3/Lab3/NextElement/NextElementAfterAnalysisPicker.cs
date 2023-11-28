using Lab3.Elements;
using Lab3.Enums;
using Lab3.Items;

namespace Lab3.NextElement;

public class NextElementAfterAnalysisPicker : INextElementPicker
{
    public static int PatientTypeChangesCount = 0;
    
    private readonly Element _transferFromLaboratoryToReceptionDepartment;
    
    public NextElementAfterAnalysisPicker(Element transferFromLaboratoryToReceptionDepartment)
    {
        _transferFromLaboratoryToReceptionDepartment = transferFromLaboratoryToReceptionDepartment;
    }
    
    
    public Element? NextElement(SimpleItem item)
    {
        if (item is Patient { Type: PatientType.WantToHospitalButHaveToPassPreliminaryExamination } patient)
        {
            PatientTypeChangesCount++;
            patient.Type = PatientType.ReadyForTreatment;
            return _transferFromLaboratoryToReceptionDepartment;
        }

        return null;
    }
}