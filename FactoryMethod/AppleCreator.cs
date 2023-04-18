namespace FactoryMethod;

public class AppleCreator : CreatorBase
{
    public override IProduct FactoryMethod()
    {
        return new Apple();
    }
}