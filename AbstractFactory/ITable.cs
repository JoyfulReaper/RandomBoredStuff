namespace AbstractFactory;

public interface ITable
{
    string Name { get; }
    void PutOn(string thing);
}