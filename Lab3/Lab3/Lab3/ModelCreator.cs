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

        var create = new Create(createDelay) { Name = "CARS_CREATOR", TimeNext = 0.1 };

        var smo1 = new SystemMO(processDelay, 1) { Name = "CASHIER1" };
        var smo2 = new SystemMO(processDelay, 1) { Name = "CASHIER2" };

        smo1.Devices[0].IsServing = true;
        smo1.Devices[0].TimeNext = processDelay.Generate();
        
        smo2.Devices[0].IsServing = true;
        smo2.Devices[0].TimeNext = processDelay.Generate();

        create.NextElement = new PriorityNextElementPicker(new List<(Element Element, int Priority)> { (smo1, 2), (smo2, 1) });

        var elements = new List<Element> { create, smo1, smo2 };
        smo1.Queue = new BankQueue(2, 3) { Elements = elements };
        smo2.Queue = new BankQueue(2, 3) { Elements = elements };

        return new NetMO(elements);
    }
}