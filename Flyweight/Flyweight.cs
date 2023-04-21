using System.Text.Json;

namespace Flyweight;

// The Flyweight stores a common portion of the state (also called intrinsic
// state) that belongs to multiple real business entities. The Flyweight
// accepts the rest of the state (extrinsic state, unique for each entity)
// via its method parameters.
public class Flyweight
{
    private Car _sharedState;

    public Flyweight(Car sharedState)
    {
        _sharedState = sharedState;
    }

    public void Operation(Car uniqueState)
    {
        string s = JsonSerializer.Serialize(_sharedState);
        string u = JsonSerializer.Serialize(uniqueState);

        Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
    }
}