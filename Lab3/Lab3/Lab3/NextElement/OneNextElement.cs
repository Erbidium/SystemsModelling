using Lab2.Elements;

namespace Lab2.NextElement;

public class OneNextElement : INextElement
{
    public OneNextElement(Element nextElement)
    {
        NextElement = nextElement;
    }
    
    public Element? NextElement { get; }
}