namespace Observer;

public class TestPublisher : PublisherBase
{
    public int State { get; private set; }

    public void ChangeState()
    {
        State = Random.Shared.Next(0, 10);
        Console.WriteLine($"Changed state: {State}");
        Notify();
    }
}