namespace Lab2;

public class Model {
    private readonly List<Element> _elements;
    
    private double _timeNext;
    
    private double _timeCurrent;
    
    private int _elementId;
    
    public Model(List<Element> elements)
        => _elements = elements;

    public void Simulate(double time)
    {
        while (_timeCurrent < time) {
            _timeNext = double.MaxValue;
            foreach (var element in _elements)
            {
                if (element.TimeNext < _timeNext)
                {
                    _timeNext = element.TimeNext;
                    _elementId = element.Id;
                }
            }
            
            Console.WriteLine($"\nIt's time for event in {_elements[_elementId].Name}, time = {_timeNext}");
            
            foreach (var element in _elements)
            {
                element.DoStatistics(_timeNext - _timeCurrent);
            }
            
            _timeCurrent = _timeNext;

            foreach (var element in _elements)
            {
                element.TimeCurrent = _timeCurrent;
            }
            
            _elements[_elementId].OutAct();

            foreach (var element in _elements)
            {
                if (element.TimeNext == _timeCurrent)
                {
                    element.OutAct();
                }
            }
            
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
            Console.WriteLine($"Failure probability = {process.Failure / (double) process.Quantity}");
        }
    }
}