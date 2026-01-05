public class Solution
{
    private Dictionary<Node, Node> copies = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        Node copy = new Node(node.val, new List<Node>());
        copies[node] = copy;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node curr = queue.Dequeue();

            foreach (Node neighbor in curr.neighbors)
            {
                if (!copies.ContainsKey(neighbor))
                {
                    copies[neighbor] = new Node(neighbor.val, new List<Node>());
                    queue.Enqueue(neighbor);
                }

                copies[curr].neighbors.Add(copies[neighbor]);
            }
        }

        return copy;
    }
}
