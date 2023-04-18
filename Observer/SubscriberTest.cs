namespace Observer;

public class SubscriberTest : ISubscriber
{
    public void Update(IPublisher publisher)
    {
        Console.WriteLine($"SubscriberTest: {(publisher as TestPublisher).State}");
    }
}