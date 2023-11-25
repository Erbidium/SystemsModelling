using Lab3.Delays;
using Lab3.Elements;
using Lab3.NextElement;
using Lab3.Queues;

namespace Lab3;

public static class ModelCreator
{
    public static NetMO GetTwoProcessModelWithPriorities()
    {
        var createDelay = new ExponentialDelay(0.5);
        var processDelay = new ExponentialDelay(0.3);

        var create = new Create(createDelay) { Name = "CREATOR", TimeNext = 0.1 };

        var process1 = new SystemMO(processDelay, 1)
        {
            Name = "PROCESSOR1",
            Queue = new Queue(2, 3)
        };

        var process2 = new SystemMO(processDelay, 1)
        {
            Name = "PROCESSOR2",
            Queue = new Queue(2, 3)
        };

        process1.Devices[0].IsServing = true;
        process2.Devices[0].IsServing = true;

        create.NextElement = new PriorityNextElementPicker(new List<(Element Element, int Priority)> { (process1, 2), (process2, 1) });

        return new NetMO(new List<Element> { create, process1, process2 });
    }
}