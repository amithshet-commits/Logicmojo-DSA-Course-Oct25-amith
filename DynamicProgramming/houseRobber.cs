public class Solution
{
    public int Rob(int[] nums)
    {
        //    int[] memo=new int[nums.Length];
        //    for(int i=0;i<nums.Length;i++)
        //         memo[i]=-1;
        //     return dfs(memo,nums,0);
        int rob1 = 0, rob2 = 0;

        foreach (int num in nums)
        {
            int temp = Math.Max(num + rob1, rob2);
            rob1 = rob2;
            rob2 = temp;
        }
        return rob2;
    }
    private int dfs(int[] memo, int[] nums, int i)
    {
        if (i >= nums.Length)
            return 0;
        if (memo[i] != -1)
            return memo[i];

        return memo[i] = Math.Max(nums[i] + dfs(memo, nums, i + 2), dfs(memo, nums, i + 1));
    }
}
