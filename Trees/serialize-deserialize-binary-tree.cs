/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null)
            return "null";

        StringBuilder sb = new StringBuilder();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            if (node == null)
            {
                sb.Append("null,");
                continue;
            }

            sb.Append(node.val).Append(",");

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data) || data == "null")
            return null;

        string[] arr = data.Split(',');

        TreeNode root = new TreeNode(int.Parse(arr[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;

        while (queue.Count > 0 && i < arr.Length)
        {
            TreeNode curr = queue.Dequeue();

            // Left child
            if (i < arr.Length && arr[i] != "null")
            {
                curr.left = new TreeNode(int.Parse(arr[i]));
                queue.Enqueue(curr.left);
            }
            i++;

            // Right child
            if (i < arr.Length && arr[i] != "null")
            {
                curr.right = new TreeNode(int.Parse(arr[i]));
                queue.Enqueue(curr.right);
            }
            i++;
        }

        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));