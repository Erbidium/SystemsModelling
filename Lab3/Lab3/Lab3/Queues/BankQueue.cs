using Lab3.Elements;

namespace Lab3.Queues;

public class BankQueue : Queue
{
    public List<Element> OtherElementsWithQueues { get; } = new();

    public override void Remove()
    {
        base.Remove();
        OnItemRemovedFromQueue();
    }

    private void OnItemRemovedFromQueue()
    {
        while (Count < MaxCount)
        {
            bool elementWasSwapped = false;
            foreach (var element in OtherElementsWithQueues)
            {
                if (element.Queue.Count == 0 || Count - element.Queue.Count <= 2)
                    continue;
                
                elementWasSwapped = true;
                Add();
                element.Queue.Remove();
                break;
            }

            if (!elementWasSwapped)
                break;
        }
    }
}