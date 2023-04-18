using Shared;

namespace AbstractFactory;

public class AbstractFactoryDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        var furnitureFactory = new WoodenFurnitureFactory();

        var chair = furnitureFactory.CreateChair();
        var table = furnitureFactory.CreateTable();

        chair.SitOn();
        table.PutOn("Book");

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Abstract Factory";
    }
}