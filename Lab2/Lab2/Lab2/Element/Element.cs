namespace Lab2;

public class Element {
    public int Id { get; }
    public string Name { get; set; }
    public double TimeCurrent { get; set; }
    public double TimeNext { get; protected set; }
    public double DelayDeviation { get; }
    public string Distribution { get; set; }
    public int Quantity { get; private set; }
    public Element? NextElement { get; set; }
    
    protected int State { get; set; }

    private readonly double _delayMean;
    
    private static int _nextId;

    protected Element(double delay)
    {
        _delayMean = delay;
        Distribution = "exp";
        Id = _nextId;
        _nextId++;
        Name = "element"+ Id;
    }

    protected double GetDelay()
    {
        return Distribution.ToLower() switch
        {
            "exp" => FunRand.Exponential(_delayMean),
            "norm" => FunRand.Normal(_delayMean, DelayDeviation),
            "unif" => FunRand.Uniform(_delayMean, DelayDeviation),
            _ => _delayMean
        };
    }
    
    public virtual void InAct() { }
    
    public virtual void OutAct(){
        Quantity++;
    }

    public void PrintResult()
        => Console.WriteLine($"{Name} quantity = {Quantity}");

    public void PrintInfo()
        => Console.WriteLine($"{Name} state= {State} quantity = {Quantity} tnext= {TimeNext}");
    
    public void DoStatistics(double delta){ }
}
