public class Solution
{
    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        List<List<int>> result = new List<List<int>>();
        List<int> list = new List<int>();
        Helper(result, nums, target, 0, 0, list);
        return result;
    }
    public void Helper(List<List<int>> result, int[] nums, int target, int currSum, int index, List<int> list)
    {
        if (currSum == target)
        {
            result.Add(new List<int>(list));
            return;
        }
        if (index >= nums.Length || currSum > target)
        {
            return;
        }
        list.Add(nums[index]);
        Helper(result, nums, target, currSum + nums[index], index, list);
        list.RemoveAt(list.Count - 1);
        Helper(result, nums, target, currSum, index + 1, list);
    }
}