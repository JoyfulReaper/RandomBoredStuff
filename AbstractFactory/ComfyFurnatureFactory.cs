namespace AbstractFactory;

public class ComfyFurnatureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ComfyChair();
    }

    public ITable CreateTable()
    {
        return new ComfyTable();
    }
}