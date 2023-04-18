using Shared;

namespace FactoryMethod;

public class FactoryMethodDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        Console.WriteLine(new AppleCreator().GetDescription());
        Console.WriteLine(new KeyboardCreator().GetDescription());

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Factory Method";
    }
}