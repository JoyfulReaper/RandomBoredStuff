namespace FactoryMethod;

public abstract class CreatorBase
{
    public abstract IProduct FactoryMethod();

    public string GetDescription()
    {
        var product = FactoryMethod();
        return $"This is a {product.Name} and it costs {product.GetCost():C2}";
    }
}