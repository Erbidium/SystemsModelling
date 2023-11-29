using Lab3.Elements;
using Lab3.Enums;
using Lab3.Items;

namespace Lab3.NextElement;

public class NextElementAfterAnalysisPicker : INextElementPicker
{
    public static int PatientTypeChangesCount = 0;
    
    private readonly Element _transferFromLaboratoryToReceptionDepartment;
    private readonly Element _endPatientServing;
    
    public NextElementAfterAnalysisPicker(Element transferFromLaboratoryToReceptionDepartment, Element endPatientServing)
    {
        _transferFromLaboratoryToReceptionDepartment = transferFromLaboratoryToReceptionDepartment;
        _endPatientServing = endPatientServing;
    }
    
    
    public Element? NextElement(SimpleItem item)
    {
        if (item is not Patient patient)
            return null;

        if (patient.Type is not PatientType.WantToHospitalButHaveToPassPreliminaryExamination)
            return _endPatientServing;
        
        PatientTypeChangesCount++;
        patient.Type = PatientType.ReadyForTreatment;
        return _transferFromLaboratoryToReceptionDepartment;

    }
}