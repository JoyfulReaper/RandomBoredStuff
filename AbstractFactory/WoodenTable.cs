namespace AbstractFactory;

public class WoodenTable : ITable
{
    public string Name => "Wooden Table";

    public void PutOn(string thing)
    {
        Console.WriteLine($"You put the {thing} on the table");
    }
}