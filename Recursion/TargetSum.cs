//For[1, 2]
//So sums = { 3, 1, 2, 0 } → sorted → {0,1,2,3}
//                 (0)
//         +1               +0
//        (1)              (0)
//     +2    +0         +2    +0
//    3      1           2      0

public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int index = nums.Length - 1;
        int currSum = 0;
        return helper(nums, target, index, currSum);
    }
    private int helper(int[] nums, int target, int index, int currSum)
    {
        if (index < 0 && currSum == target)
        {
            return 1;
        }
        if (index < 0)
        {
            return 0;
        }
        int positive = helper(nums, target, index - 1, currSum + nums[index]);
        int negative = helper(nums, target, index - 1, currSum - nums[index]);
        return positive + negative;
    }
}