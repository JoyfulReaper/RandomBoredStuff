namespace AbstractFactory;

public class WoodenFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new WoodenChair();
    }

    public ITable CreateTable()
    {
        return new WoodenTable();
    }
}