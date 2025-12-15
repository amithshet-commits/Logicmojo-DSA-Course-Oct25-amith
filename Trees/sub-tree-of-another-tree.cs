public class Solution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (root == null) return false;
        return IsSameTree(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }
    private bool IsSameTree(TreeNode p, TreeNode q)
    {
        // Base case: if both trees are null, they are identical
        if (p == null && q == null)
        {
            return true;
        }
        // If only one tree is null or the values are different, they are not identical
        if (p == null || q == null || p.val != q.val)
        {
            return false;
        }
        // Recursively check if the left and right subtrees are identical
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}