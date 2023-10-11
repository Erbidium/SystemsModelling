using Lab2.Delay;

namespace Lab2.Elements;

public class Element {
    public int Id { get; }
    public string Name { get; set; }
    public double TimeCurrent { get; set; }
    public double TimeNext { get; protected set; }
    public double DelayDeviation { get; }
    public int Quantity { get; private set; }
    public Element? NextElement { get; set; }
    
    protected int State { get; set; }

    private IDelay _delay;
    
    private static int _nextId;

    protected Element(IDelay delay)
    {
        _delay = delay;
        Id = _nextId;
        _nextId++;
        Name = $"element{Id}";
    }

    protected double GetDelay()
        => _delay.Generate();
    
    public virtual void InAct() { }
    
    public virtual void OutAct()
        => Quantity++;

    public void PrintResult()
        => Console.WriteLine($"{Name} quantity = {Quantity}");

    public void PrintInfo()
        => Console.WriteLine($"{Name} state= {State} quantity = {Quantity} tnext= {TimeNext}");
    
    public void DoStatistics(double delta){ }
}
