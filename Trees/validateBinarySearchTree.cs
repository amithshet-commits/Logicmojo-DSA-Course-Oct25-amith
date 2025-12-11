public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        return valid(root, long.MinValue, long.MaxValue);
    }
    private bool valid(TreeNode root, long minValue, long maxValue)
    {
        if (root == null)
        {
            return true;
        }
        if (!(root.val > minValue && root.val < maxValue))
        {
            return false;
        }
        return valid(root.left, minValue, root.val) && valid(root.right, root.val, maxValue);
    }
}