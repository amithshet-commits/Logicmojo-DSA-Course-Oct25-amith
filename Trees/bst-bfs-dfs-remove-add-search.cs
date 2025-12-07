public class Node
{
    public Node left;
    public Node right;
    public int val;
    public int count = 1;
    public Node(int val)
    {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

public class BST
{
    public Node root = null;

    public bool Search(int x)
    {
        Node curr = root;
        while (curr != null)
        {
            if (curr.val == x) return true;
            else if (x < curr.val) curr = curr.left;
            else curr = curr.right;
        }
        return false;
    }

    public void Insert(int x)
    {
        Node node = new Node(x);
        if (root == null)
        {
            root = node;
            return;
        }
        Node curr = root;
        while (curr != null)
        {
            if (curr.val == x)
            {
                curr.count++;
                return;
            }
            else if (x < curr.val)
            {
                if (curr.left == null)
                {
                    curr.left = node;
                }
                curr = curr.left;
            }
            else
            {
                if (curr.right == null)
                {
                    curr.right = node;
                }
                curr = curr.right;
            }
        }
    }

    public Node Remove(Node node, int x)
    {
        if (node == null) return null;

        if (node.val == x)
        {
            // Leaf node
            if (node.left == null && node.right == null)
            {
                return null;
            }
            // One child
            if (node.left == null)
            {
                return node.right;
            }
            if (node.right == null)
            {
                return node.left;
            }
            // Two children → attach right subtree to rightmost of left subtree
            if (node.left != null && node.right != null)
            {
                AttachNodeToRightMost(node.left, node.right);
                return node.left;
            }
        }
        else if (x < node.val)
        {
            node.left = Remove(node.left, x);
        }
        else
        {
            node.right = Remove(node.right, x);
        }
        return node;
    }

    private void AttachNodeToRightMost(Node parent, Node child)
    {
        if (parent.right == null)
        {
            parent.right = child;
            return;
        }
        else
        {
            AttachNodeToRightMost(parent.right, child);
        }
    }
}

// Example usage
class Program
{
    static void Main()
    {
        BST bst = new BST();
        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(7);
        bst.Insert(2);
        bst.Insert(4);
        bst.Insert(5);

        //bst.Remove(5);

        Console.WriteLine(bst.Search(7)); // true
    }
}