public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        List<IList<int>> res = new List<IList<int>>();
        if (root == null) return res;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        bool leftToRight = false;
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            leftToRight = !leftToRight;
            int levelCount = queue.Count;
            List<int> level = new List<int>();
            while (levelCount > 0)
            {
                TreeNode curr = queue.Dequeue();
                if (leftToRight)
                {
                    level.Add(curr.val);
                }
                else
                {
                    level.Insert(0, curr.val);
                }
                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
                levelCount--;
            }
            res.Add(level);
        }
        return res;
    }
}