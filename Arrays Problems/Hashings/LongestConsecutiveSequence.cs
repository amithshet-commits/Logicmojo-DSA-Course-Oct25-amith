//TC O(n) SC O(n)
static int LongestConsecutive(int[] nums)
{
    if (nums.Length == 0)
        return 0;
    HashSet<int> set = new HashSet<int>(nums);
    int max = 0;
    foreach (int num in set)
    {
        // only start counting if this number is the START of a sequence
        if (!set.Contains(num - 1))
        {
            int curr = num;
            int len = 1;
            // expand forward
            while (set.Contains(curr + 1))
            {
                curr++;
                len++;
            }
            max = Math.Max(max, len);
        }
    }
    return max;
}
//TC O(nlogn) SC O(1)
static int LongestConsecutive(int[] nums)
{
    if (nums.Length == 0)
        return 0;
    int max = 1; int currCount = 1;
    Array.Sort(nums);
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] == nums[i - 1])
        {
            continue;
        }
        if (nums[i] == nums[i - 1] + 1)
        {
            currCount++;
        }
        else if (nums[i] != nums[i - 1] + 1)
        {
            currCount = 1;
        }
        max = Math.Max(max, currCount);
    }
    return max;
}