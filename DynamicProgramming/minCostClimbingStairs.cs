public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        // int[] memo=new int[cost.Length];
        // for(int i=0;i<memo.Length;i++)
        //     memo[i]=-1;
        // return Math.Min(dfs(cost,0,memo),dfs(cost,1,memo));
        for (int i = cost.Length - 3; i >= 0; i--)
        {
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }
        return Math.Min(cost[0], cost[1]);
    }

    private int dfs(int[] cost, int i, int[] memo)
    {
        if (i >= cost.Length)
            return 0;
        if (memo[i] != -1)
            return memo[i];
        memo[i] = cost[i] + Math.Min(dfs(cost, i + 1, memo), dfs(cost, i + 2, memo));
        return memo[i];
    }
}