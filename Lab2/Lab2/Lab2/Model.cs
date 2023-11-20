using Lab2.Elements;

namespace Lab2;

public class Model {
    private readonly List<Element> _elements;
    
    private double _timeNext;
    
    private double _timeCurrent;
    
    public Model(List<Element> elements)
        => _elements = elements;

    public void Simulate(double time)
    {
        while (_timeCurrent < time)
        {
            _timeNext = _elements.Select(e => e.TimeNext).Min();
            
            _elements.ForEach(e => e.DoStatistics(_timeNext - _timeCurrent));
            
            _timeCurrent = _timeNext;

            _elements.ForEach(e => e.TimeCurrent = _timeCurrent);

            foreach (var element in _elements)
            {
                if (element.TimeNext == _timeCurrent)
                {
                    element.Exit();
                }
            }
            
            Console.WriteLine($"-----Current time: {_timeCurrent}----");
            
            PrintInfo();
        }
        PrintResult();
    }

    private void PrintInfo()
    {
        foreach (var element in _elements)
        {
            element.PrintInfo();
        }
    }

    private void PrintResult()
    {
        Console.WriteLine("\n-------------RESULTS-------------");
        
        foreach (var element in _elements) {
            element.PrintResult();
            
            if (element is not Process process)
                continue;
            
            Console.WriteLine($"Mean length of queue = {process.MeanQueue / _timeCurrent}");
            Console.WriteLine($"Failure probability = {process.Failure / (double) (process.Failure + process.ServedElementsQuantity)}");
            Console.WriteLine($"Average loading time: {process.LoadTime / _timeCurrent}");
            Console.WriteLine($"Average serving time: {process.LoadTime / process.ServedElementsQuantity}");
        }
    }
}