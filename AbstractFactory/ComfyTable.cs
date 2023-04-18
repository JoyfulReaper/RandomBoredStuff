namespace AbstractFactory;

public class ComfyTable : ITable
{
    public string Name => "Comfy Table";

    public void PutOn(string thing)
    {
        Console.WriteLine($"You put the {thing} on the comfy table, it looks comfortable there.");
    }
}