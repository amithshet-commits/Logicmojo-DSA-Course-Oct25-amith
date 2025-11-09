class Node
{
    public int val;
    public Node? next;

    public Node(int val)
    {
        this.val = val;
        this.next = null;
    }

    public override string ToString()
    {
        return val.ToString();
    }
}
class LinkedList
{
    private Node? head;
    private Node? tail;
    private int size;

    public LinkedList()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public void AddFirst(int val)
    {
        Node node = new Node(val);
        node.next = head;
        head = node;
        if (tail == null)
        {
            tail = node;
        }
        size++;
    }
    public void AddLast(int val)
    {
        Node node = new Node(val);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.next = node;
            tail = node;
        }
        size++;
    }
    public Node RemoveFirst()
    {
        Node first;
        if (size == 0)
        {
            return null;
        }
        if (size == 1)
        {
            first = head;
            head = null;
            tail = null;
            size = 0;
            return first;
        }
        Node next = head.next;
        head.next = null;
        first = head;
        head = next;
        size--;
        return first;
    }

    public override string ToString()
    {
        if (size == 0)
        {
            return "null";
        }
        Node curr = head;
        String str = "";
        while (curr.next != null)
        {
            str = str + curr.val + "->";
            curr = curr.next;
        }
        str = str + curr.val + "->null";
        return str;
    }

    public static void Main(string[] args)
    {
        LinkedList ll = new LinkedList();
        ll.AddFirst(3);
        //ll.AddFirst(2);
        //ll.AddFirst(1);
        ll.AddLast(4);
        ll.RemoveFirst();
        Console.WriteLine(ll.ToString()); // [1, 2, 3]
        Console.ReadLine();
    }
}



