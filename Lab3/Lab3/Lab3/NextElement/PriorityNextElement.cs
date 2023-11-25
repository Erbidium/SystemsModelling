using Lab3.Elements;

namespace Lab3.NextElement;

public class PriorityNextElement : INextElement
{
    private readonly List<(Element Element, int Priority)> _nextElementPriorities;
    
    private readonly Random _rand = new();
    
    public PriorityNextElement(List<(Element Element, int Priority)> nextElementPriorities)
    {
        _nextElementPriorities = nextElementPriorities;
    }

    public Element? NextElement
    {
        get
        {
            var freeElements = _nextElementPriorities.Where(tuple => !tuple.Element.IsFull).ToList();

            if (freeElements.Count > 0)
                return FindElementWithMaxPriority(freeElements);
            
            var freeQueues = _nextElementPriorities.Where(tuple => tuple.Element is SystemMO p && p.Queue < p.MaxQueue).ToList();
            
            if (freeQueues.Count > 0)
                return FindElementWithMaxPriority(freeQueues);

            return _nextElementPriorities.OrderByDescending(tuple => tuple.Priority).Select(t => t.Element).FirstOrDefault();

            Element FindElementWithMaxPriority(IReadOnlyCollection<(Element Element, int Priority)> elements)
            {
                var maxFreePriority = elements.Select(tuple => tuple.Priority).Max();
                var freeElementsWithMaxPriority = elements.Where(tuple => tuple.Priority == maxFreePriority).ToList();
                return freeElementsWithMaxPriority[_rand.Next(freeElementsWithMaxPriority.Count)].Element;
            }
        }
    }
}