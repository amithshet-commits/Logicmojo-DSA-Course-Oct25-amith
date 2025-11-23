//Intuition
//                          []
//                 /                    \
//           add 1                        remove 1
//           [1]                           []
//         /       \                     /      \
//   add 2         remove 2           add 2      remove 2
//   [1,2]          [1]             [2]         []
//   /    \         /    \         /    \       /   \
//[1,2,3] [1,2]  [1,3] [1]      [2,3] [2]   [3]   []
//   ✔       ✔       ✔      ✔         ✔     ✔     ✔     ✔

public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> result = new List<IList<int>>();
        List<int> list = new List<int>();
        Helper(0, result, nums, list);
        return result;
    }

    public void Helper(int i, List<IList<int>> result, int[] nums, List<int> list)
    {
        if (i == nums.Length)
        {
            result.Add(new List<int>(list));
            return;
        }
        list.Add(nums[i]);
        Helper(i + 1, result, nums, list);
        list.RemoveAt(list.Count - 1);
        Helper(i + 1, result, nums, list);
    }
}

//Javascript solution
function subsets(nums)
{
    let trolly = []
    helper(0, [], trolly);
    return trolly;
 
    function helper(i, bag, trolly)
    {
        if (i == nums.length)
        {
            trolly.push([...bag]);
            return
        }
        bag.push(nums[i])
        helper(i + 1, bag, trolly);
        bag.pop()
        helper(i + 1, bag, trolly);
    }
}
let nums = [1, 2, 3]
let result=subsets(nums)
console.log(result);