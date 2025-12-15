public class Solution
{
    List<int> res = new List<int>();
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null) return new List<int>();
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode curr = stack.Pop();
            res.Add(curr.val);
            if (curr.right != null)
            {
                stack.Push(curr.right);
            }
            if (curr.left != null)
            {
                stack.Push(curr.left);
            }
        }
        return res;
    }

    public IList<int> PreorderTraversalRecursive(TreeNode root)
    {
        if (root == null) return new List<int>();
        res.Add(root.val);
        PreorderTraversalRecursive(root.left);
        PreorderTraversalRecursive(root.right);
        return res;
    }
}