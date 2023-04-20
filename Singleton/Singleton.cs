namespace Singleton;

public class Singleton
{
    public string Value { get; set; }

    private static Singleton? _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton GetInstance(string value)
    {
        if(_instance == null)
        {
            lock(_lock)
            {
                if(_instance == null)
                {
                    _instance = new Singleton();
                    _instance.Value = value;
                }
            }
        }

        return _instance;
    }
}