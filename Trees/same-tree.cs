public class Solution
{
    public int sameTree(TreeNode p,TreeNode q)
    {
        return Helper(p,q);
    }
    private bool Helper(TreeNode p, TreeNode q)
    {
        if (p==null && q==null)
        {
            return true;
        }
        if (p==null || q==null || p.val!=q.val)
        {
            return false;
        }
        return Helper(p.left, q.left) && Helper(p.right,q.right);
    }
}