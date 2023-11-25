using Lab3.Elements;

namespace Lab3.NextElement;

public class OneNextElementPicker : INextElementPicker
{
    public OneNextElementPicker(Element nextElement)
    {
        NextElement = nextElement;
    }
    
    public Element? NextElement { get; }
}