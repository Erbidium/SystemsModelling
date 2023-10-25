using Lab2.Delays;

namespace Lab2.Elements;

public class Create : Element {
    public Create(IDelay delay) : base(delay)
        => TimeNext = 0.0; // імітація розпочнеться з події Create

    public override void Exit() {
        base.Exit();
        TimeNext = TimeCurrent + GetDelay();
        NextElement?.Enter();
    }
}