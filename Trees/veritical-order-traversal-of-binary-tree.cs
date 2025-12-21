public class Solution
{
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        SortedDictionary<int, SortedDictionary<int, SortedSet<int>>> sortDict = new SortedDictionary<int, SortedDictionary<int, SortedSet<int>>>();
        var queue = new Queue<(TreeNode node, int row, int col)>();
        queue.Enqueue((root, 0, 0));
        while (queue.Count > 0)
        {
            var (node, row, col) = queue.Dequeue();
            if (!sortDict.ContainsKey(col))
            {
                sortDict[col] = new SortedDictionary<int, SortedSet<int>>();
            }
            if (!sortDict[col].ContainsKey(row))
            {
                sortDict[col][row] = new SortedSet<int>();
            }
            sortDict[col][row].Add(node.val);
            if (node.left != null)
            {
                queue.Enqueue((node, row + 1, col - 1));
            }
            if (node.right != null)
            {
                queue.Enqueue((node, row + 1, col + 1));
            }
        }
        var result = new List<IList<int>>();

        foreach (var colEntry in sortDict.Values)
        {
            var colList = new List<int>();

            foreach (var rowEntry in colEntry.Values)
            {
                colList.AddRange(rowEntry);
            }

            result.Add(colList);
        }

        return result;
    }
}