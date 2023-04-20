using Shared;

namespace Builder;

public class BuilderDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        VehicleBuilder builder;
        Shop shop = new();

        builder = new ScooterBuilder();
        shop.Construct(builder);
        builder.Vehicle.Show();

        builder = new CarBuilder();
        shop.Construct(builder);
        builder.Vehicle.Show();

        builder = new MotorCycleBuilder();
        shop.Construct(builder);
        builder.Vehicle.Show();

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Builder";
    }
}
