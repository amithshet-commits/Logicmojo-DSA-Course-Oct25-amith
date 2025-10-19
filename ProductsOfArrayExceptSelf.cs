public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int prod = 1; int[] res = new int[nums.Length];
        for (int i = 0; i <= nums.Length - 1; i++)
        {
            res[i] = prod;
            prod *= nums[i];
        }
        prod = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            res[i] *= prod;
            prod *= nums[i];
        }
        return res;
    }
}