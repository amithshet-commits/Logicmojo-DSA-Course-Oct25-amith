public class Solution
{
    public bool IsFullBinaryTree(Node root)
    {
        // Empty tree is considered full
        if (root == null)
            return true;

        // Leaf node
        if (root.left == null && root.right == null)
            return true;

        // Internal node with two children
        if (root.left != null && root.right != null)
            return IsFullBinaryTree(root.left) &&
                   IsFullBinaryTree(root.right);

        // Node with only one child
        return false;
    }
}