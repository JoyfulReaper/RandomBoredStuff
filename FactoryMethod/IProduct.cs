namespace FactoryMethod;

public interface IProduct
{
    public string Name { get; init; }
    decimal GetCost();
}