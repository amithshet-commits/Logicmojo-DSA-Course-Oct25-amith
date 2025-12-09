public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        // Base Condition
        if (root == null) return 0;
        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);
        return Math.Max(left, right) + 1;
    }
}