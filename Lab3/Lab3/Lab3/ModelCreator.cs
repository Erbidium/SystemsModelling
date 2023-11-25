using Lab3.Delays;
using Lab3.Elements;
using Lab3.NextElement;

namespace Lab3;

public static class ModelCreator
{
    public static NetMO GetTwoProcessModelWithPriorities()
    {
        var createDelay = new ExponentialDelay(0.5);
        var processDelay = new ExponentialDelay(0.3);

        var create = new Create(createDelay) { Name = "CREATOR", TimeNext = 0.1 };

        var process1 = new SystemMO(1, processDelay) { Name = "PROCESSOR1", Queue = 2, MaxQueue = 3 };
        var process2 = new SystemMO(1, processDelay) { Name = "PROCESSOR2", Queue = 2, MaxQueue = 3 };

        create.NextElement = new PriorityNextElement(new List<(Element Element, int Priority)> { (process1, 1), (process2, 2) });

        return new NetMO(new List<Element> { create, process1, process2 });
    }
}