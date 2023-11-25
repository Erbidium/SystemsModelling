using Lab3.Elements;

namespace Lab3.NextElement;

public class OneNextElement : INextElement
{
    public OneNextElement(Element nextElement)
    {
        NextElement = nextElement;
    }
    
    public Element? NextElement { get; }
}