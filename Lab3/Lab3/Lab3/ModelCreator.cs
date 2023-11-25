using Lab3.Delays;
using Lab3.Elements;
using Lab3.NextElement;

namespace Lab3;

public static class ModelCreator
{
    public static Model GetOneProcessModel()
    {
        var createDelay = new ExponentialDelay(1);
        var processDelay = new ExponentialDelay(2);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process = new Process(1, processDelay) { Name = "PROCESSOR", MaxQueue = 5 };
        
        create.NextElement = new OneNextElement(process);

        return new Model(new List<Element> { create, process });
    }
    
    public static Model GetThreeProcessesModel()
    {
        var createDelay = new ExponentialDelay(1);
        var processDelay = new ExponentialDelay(2);

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
        
        var process1Delay = new ExponentialDelay(3);
        var process2Delay = new ExponentialDelay(2);
        var process3Delay = new ExponentialDelay(3.5);

        var create = new Create(createDelay) { Name = "CREATOR" };

        var process1 = new Process(3, process1Delay) { Name = "PROCESSOR1", MaxQueue = 5 };
        var process2 = new Process(1, process2Delay) { Name = "PROCESSOR2", MaxQueue = 5 };
        var process3 = new Process(2, process3Delay) { Name = "PROCESSOR3", MaxQueue = 5 };

        create.NextElement = new OneNextElement(process1);
        process1.NextElement = new OneNextElement(process2);
        process2.NextElement = new OneNextElement(process3);

        return new Model(new List<Element> { create, process1, process2, process3 });
    }
    
    public static Model GetThreeProcessesModelWithMultipleDevicesAndWeightedNextElements()
    {
        var createDelay = new ExponentialDelay(1);
        var processDelay = new ExponentialDelay(2);

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