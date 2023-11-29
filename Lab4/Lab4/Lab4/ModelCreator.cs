using System.Diagnostics;
using Lab3.Delays;
using Lab3.Elements;
using Lab3.ItemFactories;
using Lab3.Items;
using Lab3.NextElement;

namespace Lab3;

public static class ModelCreator
{
    public static NetMO CreateChainedModel(int processesCount)
    {
        var delay = new ExponentialDelay(0.5);
        var simpleItemFactory = new SimpleItemFactory();
        
        var create = new Create(delay, simpleItemFactory) { Name = "CREATOR" };

        var elements = new List<Element> { create };

        Element previousElement = create;
        
        for (int i = 0; i < processesCount; i++)
        {
            var process = new SystemMO(delay, 1) { Name = $"PROCESSOR{i + 1}" };
            
            process.Enter(new SimpleItem());
            
            previousElement.NextElement = new OneNextElementPicker(process);
            previousElement = process;
            
            elements.Add(process);
        }

        return new NetMO(elements);
    }
}