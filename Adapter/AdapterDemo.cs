using Shared;

namespace Adapter;

public class AdapterDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine("Adaptee interface is incompatible with the client.");
        Console.WriteLine("But with adapter client can call it's method.");

        Console.WriteLine(target.GetRequest());

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Adapter";
    }
}