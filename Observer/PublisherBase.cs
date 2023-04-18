namespace Observer;

public abstract class PublisherBase : IPublisher
{
    private readonly List<ISubscriber> _subscribers = new();

    public void AddSubscriber(ISubscriber subscriber)
    {
        Console.WriteLine("Added subscriber");
        _subscribers.Add(subscriber);
    }

    public void Notify()
    {
        Console.WriteLine("Notifing subscribers");
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(this);
        }
    }

    public void RemoveSubscriber(ISubscriber subscriber)
    {
        Console.WriteLine("Removed subscriber");
        _subscribers.Remove(subscriber);
    }
}