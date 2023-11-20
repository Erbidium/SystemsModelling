using Lab2.Elements;

namespace Lab2.NextElement;

public class WeightedNextElement : INextElement
{
    public WeightedNextElement(Element nextElement)
    {
        NextElement = nextElement;
    }
    
    public Element? NextElement { get; }
}