namespace FactoryMethod;

public class Keyboard : IProduct
{
    public string Name { get; init; } = "Keyboard";

    public decimal GetCost()
    {
        return 49.99m;
    }
}