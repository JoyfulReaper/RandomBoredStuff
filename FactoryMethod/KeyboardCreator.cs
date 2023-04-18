namespace FactoryMethod;

public class KeyboardCreator : CreatorBase
{
    public override IProduct FactoryMethod()
    {
        return new Keyboard();
    }
}