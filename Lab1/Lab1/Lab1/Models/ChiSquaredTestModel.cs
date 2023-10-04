namespace Lab1.Models;

public class ChiSquaredTestModel
{
    public int IntervalsCount { get; set; }
    
    public double CalculatedChiSquared { get; set; }
    
    public double TableChiSquared { get; set; }
    
    public double ConfidenceChance { get; set; }
}