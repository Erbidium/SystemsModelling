namespace Lab3.Queues;

public class Queue
{
    public int Count { get; private set; }

    public int MaxCount { get; } = int.MaxValue;
    
    public Queue() { }

    public Queue(int maxCount)
    {
        MaxCount = maxCount;
    }
    
    public Queue(int count, int maxCount)
    {
        Count = count;
        MaxCount = maxCount;
    }

    public virtual void Add()
    {
        Count++;
        
    }

    public virtual void Remove()
    {
        Count--;
    }
}