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
}
