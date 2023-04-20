namespace Builder;

/// <summary>
/// The 'Builder' abstract class
/// </summary>
public abstract class VehicleBuilder
{
    protected Vehicle _vehicle = default!;

    public Vehicle Vehicle { get => _vehicle; }

    // Abstract build methods
    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}
