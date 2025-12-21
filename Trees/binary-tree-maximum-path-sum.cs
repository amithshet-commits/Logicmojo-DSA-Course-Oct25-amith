/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution
{
    int maxSum = 0;
    public int MaxPathSum(TreeNode root)
    {
        maxSum = int.MinValue;
        MaxGain(root);
        return maxSum;
    }
    public int MaxGain(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int leftGain = Math.Max(MaxGain(root.left), 0);
        int rightGain = Math.Max(MaxGain(root.right), 0);

        int currMaxSum = root.val + leftGain + rightGain;
        maxSum = Math.Max(currMaxSum, maxSum);

        return root.val + Math.Max(leftGain, rightGain);
    }
}
