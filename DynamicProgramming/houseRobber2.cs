public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
            return nums[0];
        //    int[][] memo=new int[nums.Length][];
        //    for(int i=0;i<nums.Length;i++)
        //     memo[i]=new int[]{-1,-1};
        //    return Math.Max(dfs(memo,nums,0,1),dfs(memo,nums,1,0));
        return Math.Max(helper(nums, 1, nums.Length - 1), helper(nums, 0, nums.Length - 2));

    }
    private int dfs(int[][] memo, int[] nums, int i, int flag)
    {
        if (i >= nums.Length || (flag == 1 && i == nums.Length - 1))
            return 0;
        if (memo[i][flag] != -1)
            return memo[i][flag];
        return memo[i][flag] = Math.Max(nums[i] + dfs(memo, nums, i + 2, flag), dfs(memo, nums, i + 1, flag));
    }

    private int helper(int[] nums, int start, int end)
    {
        int rob1 = 0; int rob2 = 0;
        for (int num = start; num <= end; num++)
        {
            int temp = Math.Max(rob1 + nums[num], rob2);
            rob1 = rob2;
            rob2 = temp;
        }
        return rob2;
    }
}
