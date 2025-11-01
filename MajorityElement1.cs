//Intuition(very important)
//pick a candidate
//if another number is different → cancel it out
//majority element can never be fully cancelled because it occurs more than all others combined
//Almost like: majority element has more soldiers than any other number → in pairwise fighting majority always survives.
//Boyer–Moore Voting Algorithm
//This finds the element that appears > n/2 times in an array — in O(n) time and O(1) space.
//TC O(n) SC O(n)
//static int MajorityElement(int[] nums)
//{
//    int majority = 0;
//    Dictionary<int, int> dict = new Dictionary<int, int>();
//    for (int i = 0; i < nums.Length; i++)
//    {
//        if (dict.ContainsKey(nums[i]))
//        {
//            dict[nums[i]]++;
//        }
//        else
//        {
//            dict.Add(nums[i], 1);
//        }
//    }
//    foreach(KeyValuePair<int, int> entry in dict)
//    {
//        majority = Math.Max(entry.Value, majority);
//        if (majority > (nums.Length / 2))
//            return entry.Key;
//    }
//    return -1;
//}
//Steps
//have count = 0
//loop through array:
//if count == 0 → candidate = current element
//if current element == candidate → count++
//else count--
//after the loop → candidate is the majority element
//TC O(n) SC O(1)
static int MajorityElement(int[] nums)
{
    int count = 0;
    int candidate = 0;

    foreach (int num in nums)
    {
        if (count == 0)
            candidate = num;

        if (num == candidate)
            count++;
        else
            count--;
    }

    return candidate;
}
int[] nums = { 3, 2, 3 };
int majority = MajorityElement(nums);
Console.ReadLine();