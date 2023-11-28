using Lab3.Elements;
using Lab3.Enums;
using Lab3.Items;

namespace Lab3.NextElement;

public class NextElementAfterAnalysisPicker : INextElementPicker
{
    private Element _transferFromLaboratoryToReceptionDepartment;
    
    public NextElementAfterAnalysisPicker(Element transferFromLaboratoryToReceptionDepartment)
    {
        _transferFromLaboratoryToReceptionDepartment = transferFromLaboratoryToReceptionDepartment;
    }
    
    
    public Element? NextElement(SimpleItem item)
    {
        if (item is Patient { Type: PatientType.WantToHospitalButHaveToPassPreliminaryExamination } patient)
        {
            patient.Type = PatientType.ReadyForTreatment;
            return _transferFromLaboratoryToReceptionDepartment;
        }

        return null;
    }
}