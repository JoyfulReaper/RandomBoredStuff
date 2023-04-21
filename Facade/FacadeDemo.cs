using Shared;

namespace Facade;

public class FacadeDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        // The client code may have some of the subsystem's objects already
        // created. In this case, it might be worthwhile to initialize the
        // Facade with these objects instead of letting the Facade create
        // new instances.
        Subsystem1 subsystem1 = new Subsystem1();
        Subsystem2 subsystem2 = new Subsystem2();
        Facade facade = new Facade(subsystem1, subsystem2);
        Client.ClientCode(facade);

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Facade";
    }
}

class Client
{
    // The client code works with complex subsystems through a simple
    // interface provided by the Facade. When a facade manages the lifecycle
    // of the subsystem, the client might not even know about the existence
    // of the subsystem. This approach lets you keep the complexity under
    // control.
    public static void ClientCode(Facade facade)
    {
        Console.Write(facade.Operation());
    }
}