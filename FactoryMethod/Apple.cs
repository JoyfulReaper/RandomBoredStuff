namespace FactoryMethod;

public class Apple : IProduct
{
    public string Name { get; init; } = "Apple";

    public decimal GetCost()
    {
        return 0.99m;
    }
}