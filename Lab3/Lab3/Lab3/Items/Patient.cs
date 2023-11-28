using Lab3.Enums;

namespace Lab3.Items;

public class Patient : SimpleItem
{
    public required PatientType Type { get; set; }
}