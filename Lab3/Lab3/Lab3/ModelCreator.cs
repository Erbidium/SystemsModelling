using Lab3.Delays;
using Lab3.Elements;
using Lab3.NextElement;

namespace Lab3;

public static class ModelCreator
{
    public static NetMO GetTwoProcessModelWithPriorities()
    {
        var createDelay = new ExponentialDelay(1);
        var processDelay = new ExponentialDelay(2);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process1 = new SystemMO(3, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
        var process2 = new SystemMO(3, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };

        create.NextElement = new PriorityNextElement(new List<(Element Element, int Priority)> { (process1, 1), (process2, 2) });

        return new NetMO(new List<Element> { create, process1, process2 });
    }
}