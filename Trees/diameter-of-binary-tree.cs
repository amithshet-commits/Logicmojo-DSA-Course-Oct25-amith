public class Solution
{
    int maxDiameter = 0;
    public int DiameterOfBinaryTree(TreeNode root)
    {
        return maxDiameter;
    }
    private int Helper(TreeNode root)
    {
        if (root==null)
        {
            return 0;
        }
        int leftHeight= Helper(root.left);
        int rightHeight= Helper(root.right);
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
