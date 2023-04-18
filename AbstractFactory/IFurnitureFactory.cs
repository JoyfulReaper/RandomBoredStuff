namespace AbstractFactory;

public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}