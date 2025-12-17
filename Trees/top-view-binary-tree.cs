static List<int> TopView(TreeNode root)
{
    List<int> result = new List<int>();
    if (root == null)
    {
        return result;
    }
    SortedDictionary<int, int> topViewMap = new SortedDictionary<int, int>();
    Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
    queue.Enqueue(new Tuple<TreeNode, int>(root, 0));
    while (queue.Count > 0)
    {
        var (node, hd) = queue.Dequeue();
        if (!topViewMap.ContainsKey(hd))
        {
            topViewMap[hd] = node.data;
        }
        if (node.left != null)
        {
            queue.Enqueue(new Tuple<TreeNode, int>(node.left, hd - 1));
        }
        if (node.right != null)
        {
            queue.Enqueue(new Tuple<TreeNode, int>(node.right, hd + 1));
        }
    }
    foreach (var key in topViewMap.Keys)
    {
        result.Add(topViewMap[key]);
    }
    return result;
}