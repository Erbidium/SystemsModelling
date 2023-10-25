using Lab2.Delays;

namespace Lab2.Elements;

public class Process : Element
{
    public int Queue { get; set; }
    
    public int Failure { get; private set; }
    public int MaxQueue { get; init; } = int.MaxValue;
    public double MeanQueue { get; private set; }
    
    public double LoadTime { get; private set; }

    public List<Device> Devices { get; } = new();

    public Process(int devicesCount, IDelay delay) : base(delay)
    {
        for (int i = 0; i < devicesCount; i++)
        {
            Devices.Add(new Device(i));
        }
    }
    
    public override void Enter()
    {
        if (!IsServing)
        {
            IsServing = true;
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

    public override void Exit()
    {
        base.Exit();
        TimeNext = double.MaxValue;
        IsServing = false;
        if (Queue > 0)
        {
            Queue--;
            IsServing = true;
            TimeNext = TimeCurrent + GetDelay();
        }
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Failure = " + Failure);
    }

    public override void DoStatistics(double delta)
    {
        MeanQueue += Queue * delta;
        if (IsServing)
            LoadTime += delta;
    }
}
