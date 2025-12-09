public class Solution
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        return Helper(root, key);
    }
    public TreeNode Helper(TreeNode root, int key)
    {
        if (root == null)
        {
            return null;
        }
        if (key == root.val)
        {
            if (root.left == null && root.right == null)
            {
                return null;
            }
            if (root.left == null)
            {
                return root.right;
            }
            if (root.right == null)
            {
                return root.left;
            }
            if (root.left != null && root.right != null)
            {
                AttachNodeToRightMost(root.left, root.right);
                return root.left;
            }
        }
        else if (key < root.val)
        {
            root.left = Helper(root.left, key);
        }
        else
        {
            root.right = Helper(root.right, key);
        }
        return root;
    }

    public void AttachNodeToRightMost(TreeNode parent, TreeNode child)
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