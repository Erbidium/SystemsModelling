using Lab2.Delays;

namespace Lab2.Elements;

public class Device : Element
{
    public Device(IDelay delay) : base(delay) { }
    
    public override void Enter()
    {
        IsServing = true;
        TimeNext = TimeCurrent + GetDelay();
    }

    public override void Exit()
    {
        IsServing = false;
        TimeNext = double.MaxValue;
        base.Exit();
    }
}