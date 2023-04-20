using Shared;

namespace Bridge;

public class BridgeDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        Client client = new Client();

        Abstraction abstraction;
        // The client code should be able to work with any pre-configured
        // abstraction-implementation combination.
        abstraction = new Abstraction(new ConcreteImplementationA());
        client.ClientCode(abstraction);

        Console.WriteLine();

        abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
        client.ClientCode(abstraction);

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Bridge";
    }
}

public class Client
{
    // Except for the initialization phase, where an Abstraction object gets
    // linked with a specific Implementation object, the client code should
    // only depend on the Abstraction class. This way the client code can
    // support any abstraction-implementation combination.
    public void ClientCode(Abstraction abstraction)
    {
        Console.Write(abstraction.Operation());
    }
}