using Lab3.Elements;
using Lab3.Items;

namespace Lab3.Queues;

public class BankQueue : Queue
{
    public List<Element> Elements { get; init; } = new();
    
    public BankQueue() { }

    public BankQueue(int maxCount) : base(maxCount) { }
    
    public BankQueue(IEnumerable<SimpleItem> items, int maxCount) : base(items, maxCount) { }
    
    public override void Add(SimpleItem item)
    {
        base.Add(item);
        OnQueueChanged();
    }

    public override SimpleItem Remove()
    {
        var removedItem = base.Remove();
        
        OnQueueChanged();

        return removedItem;
    }

    private void OnQueueChanged()
    {
        foreach (var elementWithQueueToFill in Elements)
        {
            if (elementWithQueueToFill is SystemMO && elementWithQueueToFill.Queue.Items.Count < elementWithQueueToFill.Queue.MaxCount)
            {
                foreach (var elementWithExcessiveQueue in Elements)
                {
                    if (elementWithQueueToFill is SystemMO && elementWithExcessiveQueue.Queue.Items.Count > 0 && elementWithExcessiveQueue.Queue.Items.Count - elementWithQueueToFill.Queue.Items.Count >= 2)
                    {
                        var car = elementWithExcessiveQueue.Queue.Remove();
                        elementWithQueueToFill.Queue.Add(car);

                        SystemMO.QueueChangesCount++;
                    }
                    
                    if (elementWithQueueToFill.Queue.Items.Count == elementWithQueueToFill.Queue.MaxCount)
                        break;
                }
            }
        }
    }
}