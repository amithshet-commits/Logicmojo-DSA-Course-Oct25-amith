helper(0, [])
      |
------------------------------------------------

|                                              |
i = 0                                          i = 1 is skipped? NO
                pick 1                                         pick 2
                   |                                              |
             helper(1, [1])                                 helper(2, [2])
                   |                                              |
       ------------------------                           -------------------------
       |                      |                           |                       |
   i = 1 pick 2           i = 2 pick 2?                 i = 2 pick 2          i = 3 end
     (valid)               (valid)                      (valid)
       |                      |                           |
 helper(2,[1, 2])      helper(3,[1, 2, 2])           helper(3,[2, 2])
       |                      |
   ---------              ----------
   |       |              |        |
i=2 duplicate? YES   i=3 end   end
SKIP

public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> list = new List<int>();
        result.Add(new List<int>());
        Array.Sort(nums);
        Helper(0, nums, list, result);
        return result;
    }
    private void Helper(int index, int[] nums, List<int> list, List<IList<int>> result)
    {
        for (int i = index; i < nums.Length; i++)
        {
            if (i != index && nums[i] == nums[i - 1])
            {
                continue;
            }
            list.Add(nums[i]);
            result.Add(new List<int>(list));
            Helper(i + 1, nums, list, result);
            list.RemoveAt(list.Count - 1);
        }
    }
}

//Javascript solution
function subsetsWithDup(nums)
{
    let trolly = []
    let bag = []
    nums.sort((a, b) => a - b);
    trolly.push([]);
    helper(0, bag, trolly);
    return trolly;
    function helper(index, bag, trolly)
    {
        for (let i = index; i < nums.length; i++)
        {
            if (i != index && nums[i] == nums[i - 1])
            {
                continue;
            }
            bag.push(nums[i]);
            trolly.push([...bag]);
            helper(i + 1, bag, trolly);
            bag.pop();
        }
    }
}