using Lab2.Delays;
using Lab2.Elements;
using Lab2.NextElement;

namespace Lab2;

public static class ModelCreator
{
    public static Model GetOneProcessModel()
    {
        var createDelay = new ExponentialDelay(1);
        var processDelay = new ExponentialDelay(1);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process = new Process(1, processDelay) { Name = "PROCESSOR", MaxQueue = 5 };

        return new Model(new List<Element> { create, process });
    }
    
    public static Model GetThreeProcessesModel()
    {
        var createDelay = new ExponentialDelay(2);
        var processDelay = new ExponentialDelay(1);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process1 = new Process(1, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
        var process2 = new Process(1, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };
        var process3 = new Process(1, processDelay) { Name = "PROCESSOR3", MaxQueue = 5 };

        create.NextElement = new OneNextElement(process1);
        process1.NextElement = new OneNextElement(process2);
        process2.NextElement = new OneNextElement(process3);

        return new Model(new List<Element> { create, process1, process2, process3 });
    }
    
    public static Model GetThreeProcessesModelWithMultipleDevices()
    {
        var createDelay = new ExponentialDelay(2);
        var processDelay = new ExponentialDelay(1);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process1 = new Process(3, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
        var process2 = new Process(3, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };
        var process3 = new Process(3, processDelay) { Name = "PROCESSOR3", MaxQueue = 5 };

        create.NextElement = new OneNextElement(process1);
        process1.NextElement = new OneNextElement(process2);
        process2.NextElement = new OneNextElement(process3);

        return new Model(new List<Element> { create, process1, process2, process3 });
    }
    
    public static Model GetThreeProcessesModelWithMultipleDevicesAndWeightedNextElements()
    {
        var createDelay = new ExponentialDelay(2);
        var processDelay = new ExponentialDelay(1);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process1 = new Process(3, processDelay) { Name = "PROCESSOR1", MaxQueue = 5 };
        var process2 = new Process(3, processDelay) { Name = "PROCESSOR2", MaxQueue = 5 };
        var process3 = new Process(3, processDelay) { Name = "PROCESSOR3", MaxQueue = 5 };

        create.NextElement = new WeightedNextElement
        {
            NextElementChances = new() { (process1, 1) }
        };
        process1.NextElement = new WeightedNextElement
        {
            NextElementChances = new() { (process2, 0.4), (process3, 0.6) }
        };
        process2.NextElement = new WeightedNextElement
        {
            NextElementChances = new() { (process1, 0.3), (process3, 0.7) }
        };

        return new Model(new List<Element> { create, process1, process2, process3 });
    }
}