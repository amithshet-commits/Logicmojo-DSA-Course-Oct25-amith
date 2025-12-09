public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> eachLevelElements = new List<int>();
            while (levelSize > 0)
            {
                TreeNode curr = queue.Dequeue();
                eachLevelElements.Add(curr.val);
                if (curr.left != null)
                {
                    queue.Enqueue(curr.left);
                }
                if (curr.right != null)
                {
                    queue.Enqueue(curr.right);
                }
                levelSize--;
            }
            result.Add(eachLevelElements);
        }
        return result;
    }
}