namespace Lab2.Elements;

public class Device
{
    public int Id { get; set; }

    public double TimeNext { get; private set; } = double.MaxValue;

    public Device(int id)
    {
        Id = id;
    }
}