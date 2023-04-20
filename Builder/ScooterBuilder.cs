namespace Builder;

public class ScooterBuilder : VehicleBuilder
{
    public ScooterBuilder()
    {
        _vehicle = new("Scooter");
    }

    public override void BuildDoors()
    {
        _vehicle["doors"] = "0";
    }

    public override void BuildEngine()
    {
        _vehicle["engine"] = "50 cc";
    }

    public override void BuildFrame()
    {
        _vehicle["frame"] = "Scooter Frame";
    }

    public override void BuildWheels()
    {
        _vehicle["wheels"] = "2";
    }
}