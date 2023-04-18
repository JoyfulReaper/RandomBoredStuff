using Shared;

namespace Observer;

public class ObserverDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        var p1 = new TestPublisher();
        var s1 = new SubscriberTest();

        p1.AddSubscriber(s1);
        p1.ChangeState();

        p1.RemoveSubscriber(s1);
        p1.ChangeState();

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Observer";
    }
}