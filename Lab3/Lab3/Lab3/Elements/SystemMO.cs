﻿using Lab3.Delays;
using Lab3.Queues;

namespace Lab3.Elements;

public class SystemMO : Element
{
    public int Failure { get; private set; }
    
    public double MeanQueue { get; private set; }
    public double LoadTime { get; private set; }
    public double MeanWorkingDevices { get; private set; }

    public List<Device> Devices { get; } = new();

    private double _timeCurrent;

    public override double TimeCurrent
    {
        get => _timeCurrent;
        set
        {
            _timeCurrent = value;
            foreach (var device in Devices)
            {
                device.TimeCurrent = value;
            }
        }
    }
    
    public override double TimeNext => Devices.Count > 0 ? Devices.Min(d => d.TimeNext) : double.MaxValue;

    public override bool IsServing => Devices.Any(d => d.IsServing);

    public override bool IsFull => Devices.All(d => d.IsServing);

    public SystemMO(IDelay delay, int devicesCount) : base(delay)
    {
        for (int i = 0; i < devicesCount; i++)
            Devices.Add(new Device(delay));
    }
    
    public override void Enter()
    {
        if (!IsFull)
        {
            var freeDevice = Devices.First(d => !d.IsServing);
            freeDevice.Enter();
        }
        else if (Queue.Count < Queue.MaxCount)
        {
            Queue.Add();
        }
        else
        {
            Failure++;
        }
    }

    public override void Exit()
    {
        var finishedDevices = Devices.FindAll(d => d.TimeNext == TimeNext);
        
        ServedElementsQuantity += finishedDevices.Count;

        foreach (var device in finishedDevices)
        {
            device.Exit();
            
            if (Queue.Count > 0)
            {
                Queue.Remove();
                device.Enter();
            }
        }
        
        NextElement?.NextElement?.Enter();
    }

    public override void PrintResult()
    {
        base.PrintResult();
        Console.WriteLine("Failure quantity = " + Failure);
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine("Failure quantity = " + Failure);
    }

    public override void DoStatistics(double delta)
    {
        MeanQueue += Queue.Count * delta;
        
        if (!IsServing)
            return;
        
        MeanWorkingDevices += Devices.Count(d => d.IsServing) * delta;
        LoadTime += delta;
    }
}
