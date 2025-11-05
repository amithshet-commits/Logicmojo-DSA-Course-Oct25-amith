//Maximum SubArray
//Kadane's algorithm
//walk from left → right.
//at every index i, you ask a simple question:
//is it better to continue the current subarray
//or start fresh from this element?
//carry current sum only if it’s positive.
public int MaxSubArray(int[] nums)
{
    int maxSub = nums[0];
    int currSum = 0;
    for (int i = 0; i <= nums.Length - 1; i++)
    {
        if (currSum < 0)
        {
            currSum = 0;
        }
        currSum += nums[i];
        maxSub = Math.Max(maxSub, currSum);
    }
    return maxSub;
}
int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
int result = MaxSubArray(nums);
Console.ReadLine();