namespace AbstractFactory;

public class ComfyChair : IChair
{
    public string Name => "Comfy Chair";

    public void SitOn()
    {
        Console.WriteLine("The comfy chair is very comfortable");
    }
}