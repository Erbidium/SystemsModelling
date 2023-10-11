using Lab2.Delays;

namespace Lab2.Elements;

public class Process : Element
{
    public int Queue { get; set; }
    
    public int Failure { get; set; }
    public int MaxQueue { get; set; }
    public double MeanQueue { get; set; }
    public Process(IDelay delay) : base(delay)
        => MaxQueue = int.MaxValue;
    
    public override void InAct()
    {
        if (State == 0)
        {
            State = 1;
            TimeNext = TimeCurrent + GetDelay();
        }
        else if (Queue < MaxQueue)
        {
            Queue++;
        }
        else
        {
            Failure++;
        }
    }

    public override void OutAct()
    {
        base.OutAct();
        TimeNext = double.MaxValue;
        State = 0;
        if (Queue > 0)
        {
            Queue--;
            State = 1;
            TimeNext = TimeCurrent + GetDelay();
        }
    }
    
    public void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Failure = " + Failure);
    }
    
    public void DoStatistics(double delta)
        => MeanQueue += Queue * delta;
}
