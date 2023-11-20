﻿using Lab2.Delays;

namespace Lab2.Elements;

public class Element {
    public int Id { get; }
    public string Name { get; set; }
    public double TimeCurrent { get; set; }
    public virtual double TimeNext { get; protected set; }

    public int ServedElementsQuantity { get; protected set; }
    public Element? NextElement { get; set; }
    
    public bool IsServing { get; set; }

    private IDelay _delay;
    
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

    public void PrintResult()
        => Console.WriteLine($"{Name} quantity = {ServedElementsQuantity}");

    public virtual void PrintInfo()
        => Console.WriteLine($"{Name} is {(IsServing ? "serving" : "waiting")}. Quantity = {ServedElementsQuantity} TimeNext = {TimeNext}");
    
    public virtual void DoStatistics(double delta){ }
}
