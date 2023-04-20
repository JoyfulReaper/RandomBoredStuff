namespace Builder;

public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder()
    {
        _vehicle = new("MotorCycle");
    }

    public override void BuildDoors()
    {
        _vehicle["doors"] = "0";
    }

    public override void BuildEngine()
    {
        _vehicle["engine"] = "500 cc";
    }

    public override void BuildFrame()
    {
        _vehicle["frame"] = "MotorCycle Frame";
    }

    public override void BuildWheels()
    {
        _vehicle["wheels"] = "2";
    }
}