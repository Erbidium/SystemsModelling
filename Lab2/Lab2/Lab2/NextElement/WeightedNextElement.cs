using Lab2.Elements;

namespace Lab2.NextElement;

public class WeightedNextElement : INextElement
{

    public List<(Element Element, double Chance)> NextElementChances = new();
    
    private readonly Random _rand = new();

    public Element? NextElement
    {
        get
        {
            double totalChancesSum = NextElementChances.Sum(el => el.Chance);
            double chanceGeneratedValue = _rand.NextDouble() * totalChancesSum;
            
            double chancesAccumulatedSum = 0;
            for (int i = 0; i < NextElementChances.Count; i++)
            {
                chancesAccumulatedSum += NextElementChances[i].Chance;
                if (chancesAccumulatedSum > chanceGeneratedValue)
                {
                    return NextElementChances[i].Element;
                }
            }
            return null;
        }
    }
}