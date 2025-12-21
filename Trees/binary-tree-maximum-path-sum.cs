public class solution
{
    int maxSum = 0;
    public int MaxPathSum(TreeNode root)
    {
        return maxSum;
    }
    public int MaxGain(TreeNode root)
    {
        if (root==null)
        {
            return 0;
        }
        int leftGain = Math.Max(MaxGain(root.left, 0));
        int rightGain = Math.Max(MaxGain(root.right, 0));

        int currMaxSum=root.val+leftGain + rightGain;
        maxSum = Math.Max(currMaxSum,maxSum);

        return root.val + Math.Max(leftGain, rightGain);
    }
}