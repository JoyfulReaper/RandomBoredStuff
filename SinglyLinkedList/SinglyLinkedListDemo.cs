using Shared;

namespace SinglyLinkedList;

public class SinglyLinkedListDemo : IDemoApp
{
    public Task ExecuteAsync()
    {
        var linkedList = new LinkedList<int>();
        linkedList.Add(1);
        linkedList.Add(2);

        Console.WriteLine("Does list contain 3? " + linkedList.Contains(3));
        linkedList.Add(3);
        Console.WriteLine("Does list contain 3? " + linkedList.Contains(3));

        Console.WriteLine("Index of 2? " + linkedList.IndexOf(2));

        DisplayLinkedList(linkedList);

        return Task.CompletedTask;
    }

    public string GetMenuEntry()
    {
        return "Singly Linked List";
    }

    private void DisplayLinkedList<T>(LinkedList<T> list)
    {
        var current = list.Head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}
