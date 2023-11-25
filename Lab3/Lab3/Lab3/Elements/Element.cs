using Lab2.Delays;
using Lab2.NextElement;

namespace Lab2.Elements;

public abstract class Element {
    private int Id { get; }
    public string Name { get; set; }
    public virtual double TimeCurrent { get; set; }
    public virtual double TimeNext { get; protected set; }

    public int ServedElementsQuantity { get; protected set; }
    public INextElement? NextElement { get; set; }
    
    public virtual bool IsServing { get; set; }

    private readonly IDelay _delay;
    
    protected Element(IDelay delay)
    {
        _delay = delay;
        Id = IdentifierGenerator.GetId();
        Name = $"element{Id}";
    }

    protected double GetDelay()
        => _delay.Generate();
    
    public virtual void Enter() { }
    
    public virtual void Exit()
        => ServedElementsQuantity++;

    public virtual void PrintResult()
        => Console.WriteLine($"{Name} served quantity = {ServedElementsQuantity}");

    public virtual void PrintInfo()
        => Console.WriteLine($"{Name} is {(IsServing ? "serving" : "waiting")}. Served quantity = {ServedElementsQuantity} TimeNext = {TimeNext}");

    public abstract void DoStatistics(double delta);
}
