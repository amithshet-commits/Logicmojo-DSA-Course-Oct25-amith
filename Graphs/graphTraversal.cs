public class Node
{
    public string Val;
    public Dictionary<Node, int> Neighbors;
    public Node(int val)
    {
        Val = val;
        Neighbors = new Dictionary<Node, int>();
    }
    public void AddConnection(Node node, int weight)
    {
        Neighbors[node] = weight;
        node.Neighbors[this] = weight;
    }
}
public class GraphTraversal
{
    public static void BFS(Node start)
    {
        Queue<Node> queue = new Queue<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        List<List<string>> result = new List<List<string>>();
        queue.Enqueue(start);
        visited.Add(start);
        while (queue.Count>0)
        {
            int levelSize= queue.Count;
            List<string> level= new List<string>();
            for (int i=0;i<levelSize;i++)
            {
                Node node= queue.Dequeue();
                level.Add(node.Val);
                foreach (var neighbor in node.Neighbors.Keys)
                {
                    if (visited.Contains(neighbor))
                        continue;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            result.Add(level);
        }
    }
    public static void DFS(Node node)
    {
        HashSet<string> visited = new HashSet<string>();
        DFSHelper(node, visited);
    }

    private static void DFSHelper(Node node, HashSet<string> visited)
    {
        visited.Add(node.Val);
        Console.WriteLine(node.Val);

        foreach (var neighbor in node.Neighbors.Keys)
        {
            if (visited.Contains(neighbor.Val)) continue;
            DFSHelper(neighbor, visited);
        }
    }
    static void Main(string[] args)
    {
        // Nodes
        Node a = new Node("a");
        Node b = new Node("b");
        Node c = new Node("c");
        Node d = new Node("d");
        Node e = new Node("e");
        Node f = new Node("f");
        Node g = new Node("g");
        Node h = new Node("h");
        Node i = new Node("i");
        Node j = new Node("j");
        Node k = new Node("k");
        Node l = new Node("l");
        Node m = new Node("m");

        // Connections
        a.AddConnection(b, 0);
        a.AddConnection(c, 0);
        a.AddConnection(d, 0);
        a.AddConnection(e, 0);

        b.AddConnection(f, 0);
        b.AddConnection(g, 0);

        c.AddConnection(h, 0);
        c.AddConnection(i, 0);

        d.AddConnection(m, 0);
        d.AddConnection(l, 0);

        e.AddConnection(j, 0);
        e.AddConnection(k, 0);

        // DFS
        //GraphTraversal.DFS(a);

        // BFS
        GraphTraversal.BFS(a);

        Console.ReadLine();
    }
}