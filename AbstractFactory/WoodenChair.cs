namespace AbstractFactory;

public class WoodenChair : IChair
{
    public string Name => "Wooden Chair";

    public void SitOn()
    {
        Console.WriteLine("The wooden chair creaks, but holds your weight");
    }
}