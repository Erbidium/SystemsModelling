using Lab3.Elements;
using Lab3.Items;

namespace Lab3.NextElement;

public class WeightedNextElementPicker : INextElementPicker
{
    public List<(Element Element, double Chance)> NextElementChances = new();
    
    private readonly Random _rand = new();

    public Element? NextElement(SimpleItem item)
    {
        double totalChancesSum = NextElementChances.Sum(el => el.Chance);
        double chanceGeneratedValue = _rand.NextDouble() * totalChancesSum;
            
        double chancesAccumulatedSum = 0;
        for (int i = 0; i < NextElementChances.Count; i++)
        {
            chancesAccumulatedSum += NextElementChances[i].Chance;
            if (chancesAccumulatedSum > chanceGeneratedValue)
            {
                var element = NextElementChances[i].Element;
                Console.WriteLine($"To element {element.Name}");
                return element;
            }
        }
        return null;
    }
}