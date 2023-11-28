using Lab3.Delays;
using Lab3.Items;

namespace Lab3.Elements;

public sealed class Create : Element {
    public Create(IDelay delay) : base(delay)
        => TimeNext = 0.0; // імітація розпочнеться з події Create

    public override void Exit() {
        base.Exit();
        TimeNext = TimeCurrent + GetDelay();

        var createdItem = new SimpleItem();
        
        NextElement?.NextElement(createdItem)?.Enter(createdItem);
    }

    public override void DoStatistics(double delta) { }
}