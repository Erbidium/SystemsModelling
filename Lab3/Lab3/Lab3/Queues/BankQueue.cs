using Lab3.Elements;

namespace Lab3.Queues;

public class BankQueue : Queue
{
    public List<Element> Elements { get; init; } = new();
    
    public BankQueue() { }

    public BankQueue(int maxCount) : base(maxCount) { }
    
    public BankQueue(int count, int maxCount) : base(count, maxCount) { }
    
    public override void Add()
    {
        base.Add();
        OnQueueChanged();
    }

    public override void Remove()
    {
        base.Remove();
        OnQueueChanged();
    }

    private void OnQueueChanged()
    {
        foreach (var elementWithQueueToFill in Elements)
        {
            if (elementWithQueueToFill.Queue.Count < elementWithQueueToFill.Queue.MaxCount)
            {
                foreach (var elementWithExcessiveQueue in Elements)
                {
                    if (elementWithExcessiveQueue.Queue.Count > 0 && elementWithExcessiveQueue.Queue.Count - elementWithQueueToFill.Queue.Count >= 2)
                    {
                        elementWithExcessiveQueue.Queue.Remove();
                        elementWithQueueToFill.Queue.Add();

                        SystemMO.QueueChangesCount++;
                    }
                    
                    if (elementWithQueueToFill.Queue.Count == elementWithQueueToFill.Queue.MaxCount)
                        break;
                }
            }
        }
    }
}