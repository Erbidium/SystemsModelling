namespace Lab2;

public class Create : Element {
    public Create(double delay) : base(delay)
        => TimeNext = 0.0; // імітація розпочнеться з події Create

    public override void OutAct() {
        base.OutAct();
        TimeNext = TimeCurrent + GetDelay();
        NextElement?.InAct();
    }
}