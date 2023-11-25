using Lab3.Delays;

namespace Lab3.Elements;

public sealed class Create : Element {
    public Create(IDelay delay) : base(delay)
        => TimeNext = 0.0; // імітація розпочнеться з події Create

    public override void Exit() {
        base.Exit();
        TimeNext = TimeCurrent + GetDelay();
        NextElement?.NextElement?.Enter();
    }

    public override void DoStatistics(double delta) { }
}