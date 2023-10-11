namespace Lab2;

public static class FunRand {
    public static double Exponential(double timeMean)
    {
        var random = new Random();
        
        double randomNumber = 0;
        while (randomNumber == 0)
            randomNumber = random.NextDouble();
        
        return -timeMean * Math.Log(randomNumber);
    }

    public static double Uniform(double timeMin, double timeMax)
    {
        var random = new Random();
        
        double randomNumber = 0;
        while (randomNumber == 0)
            randomNumber = random.NextDouble();
        
        return timeMin + randomNumber * (timeMax - timeMin);
    }

    public static double Normal(double timeMean, double timeDeviation)
    {
        var random = new Random();
        
        double randomNumber = random.NextDouble();
        
        return timeMean + timeDeviation * randomNumber;
    }
}