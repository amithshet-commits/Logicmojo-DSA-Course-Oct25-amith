//Boyer–Moore Voting Algorithm
//This finds the element that appears > n/3 times in an array — in O(n) time and O(1) space.
//Phase 1 – find candidates
//if number == candidate1 → count1++
//else if number == candidate2 → count2++
//else if count1 == 0 → candidate1 = num, count1 = 1
//else if count2 == 0 → candidate2 = num, count2 = 1
//else → both counts-- (pair cancel)
//Phase 2 – verify the candidates
//because the 2 candidates found may not actually be > n/3
//so we count again.
static IList<int> MajorityElement2(int[] nums)
{
    int count1 = 0, count2 = 0;
    int candidate1 = 0, candidate2 = 0;
    IList<int> majority = new List<int>();
    foreach (int num in nums)
    {
        if (candidate1 == num)
            count1++;
        else if (candidate2 == num)
            count2++;
        else if (count1 == 0)
        {
            candidate1 = num; count1++;
        }
        else if (count2 == 0)
        {
            candidate2 = num; count2++;
        }
        else
        {
            count1--;
            count2--;
        }
    }
    count1 = 0; count2 = 0;
    foreach (int num in nums)
    {
        if (num == candidate1)
            count1++;
        else if (num == candidate2)
            count2++;
        if (count1 > nums.Length / 3 && !majority.Contains(candidate1))
        {
            majority.Add(candidate1);
        }
        if (count2 > nums.Length / 3 && !majority.Contains(candidate2))
        {
            majority.Add(candidate2);
        }
    }
    return majority;
}
int[] nums = { 1, 2 };
IList<int> majority = MajorityElement2(nums);
Console.ReadLine();