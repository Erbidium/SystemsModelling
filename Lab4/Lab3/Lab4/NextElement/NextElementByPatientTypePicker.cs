using Lab3.Elements;
using Lab3.Enums;
using Lab3.Items;

namespace Lab3.NextElement;

public class NextElementByPatientTypePicker : INextElementPicker
{
    private readonly List<(Element Element, PatientType PatientType)> _elementsForPatientsByTypes;
    
    public NextElementByPatientTypePicker(List<(Element Element, PatientType PatientType)> elementsForPatientsByTypes)
    {
        _elementsForPatientsByTypes = elementsForPatientsByTypes;
    }

    public Element? NextElement(SimpleItem item)
    {
        return item is Patient patient
            ? _elementsForPatientsByTypes.FirstOrDefault(elementForType => elementForType.PatientType == patient.Type).Element
            : null;
    }
}