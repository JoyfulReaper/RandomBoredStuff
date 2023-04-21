using Shared;

namespace Composite;

public class CompositeDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        Client client = new Client();

        // This way the client code can support the simple leaf
        // components...
        Leaf leaf = new Leaf();
        Console.WriteLine("Client: I get a simple component:");
        client.ClientCode(leaf);

        // ...as well as the complex composites.
        Composite tree = new Composite();
        Composite branch1 = new Composite();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());
        Composite branch2 = new Composite();
        branch2.Add(new Leaf());
        tree.Add(branch1);
        tree.Add(branch2);
        Console.WriteLine("Client: Now I've got a composite tree:");
        client.ClientCode(tree);

        Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
        client.ClientCode2(tree, leaf);

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Composite";
    }
}

class Client
{
    // The client code works with all of the components via the base
    // interface.
    public void ClientCode(Component leaf)
    {
        Console.WriteLine($"RESULT: {leaf.Operation()}\n");
    }

    // Thanks to the fact that the child-management operations are declared
    // in the base Component class, the client code can work with any
    // component, simple or complex, without depending on their concrete
    // classes.
    public void ClientCode2(Component component1, Component component2)
    {
        if (component1.IsComposite())
        {
            component1.Add(component2);
        }

        Console.WriteLine($"RESULT: {component1.Operation()}");
    }
}