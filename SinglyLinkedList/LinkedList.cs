namespace SinglyLinkedList;

public class LinkedList<T>
{
    public Node<T>? Head { get; private set; }

    public void Add(T item)
    {
        var currentNode = Head;
        var previousNode = Head;
        while (currentNode != null)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        currentNode = new Node<T>(item);
        if (previousNode == null)
        {
            Head = currentNode;
        }
        else
        {
            previousNode.Next = currentNode;
        }
    }

    public void Clear()
    {
        Head = null;
    }

    public bool Contains(object? value)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value?.Equals(value) ?? false)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    public int IndexOf(object? value)
    {
        var currentNode = Head;
        var index = 0;
        while (currentNode != null)
        {
            if (currentNode.Value?.Equals(value) ?? false)
            {
                return index;
            }
            currentNode = currentNode.Next;
            index++;
        }
        return -1;
    }
}
