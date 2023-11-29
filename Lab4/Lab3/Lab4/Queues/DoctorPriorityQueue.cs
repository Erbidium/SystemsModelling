using Lab3.Enums;
using Lab3.Items;

namespace Lab3.Queues;

public class DoctorPriorityQueue : Queue
{
    private PatientType _priorityPatients;

    public DoctorPriorityQueue(PatientType priorityPatients)
    {
        _priorityPatients = priorityPatients;
    }
    
    public override SimpleItem Remove()
    {
        foreach (var item in Items)
        {
            if (item is Patient patient && patient.Type == _priorityPatients)
            {
                Items.Remove(item);
                return item;
            }
        }
        
        return base.Remove();
    }
}