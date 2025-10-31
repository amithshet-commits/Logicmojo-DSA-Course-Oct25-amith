// Given an array nums containing n distinct numbers in the range [0, n],
// return the only number in the range that is missing from the array.
//Intuition:
//The sum of the first n natural numbers can be calculated using the formula n * (n + 1) / 2.
// Or can be looped through to get the expected sum from 0 to n.
//By calculating the expected sum of numbers from 0 to n and subtracting the actual
//sum of the elements in the array, we can find the missing number.
static int MissingNumber(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Length + 1; i++)
    {
        sum += i;
    }
    for (int i = 0; i < nums.Length; i++)
    {
        sum -= nums[i];
    }
    return sum;
}
static int MissingNumber(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
    }
    int expectedSum = nums.Length * (nums.Length + 1) / 2;
    return expectedSum - sum;
}
static int MissingNumber(int[] nums)
{
    bool[] tracker = new bool[nums.Length + 1];
    for (int i = 0; i < nums.Length; i++)
    {
        tracker[nums[i]] = true;
    }
    int j;
    for (j = 0; j < tracker.Length; j++)
    {
        if (!tracker[j])
        {
            return j;
        }
    }
    return j;
}
//XOR Intuition
//key XOR properties:
//a ^ a = 0 → same numbers cancel each other out.
//a ^ 0 = a → XOR with zero changes nothing.
static int MissingNumber(int[] nums)
{
    int xor = 0;
    // XOR all numbers in the array
    foreach (int num in nums)
    {
        xor ^= num;
    }
    // XOR all numbers from 0 to n
    for (int i = 0; i <= nums.Length; i++)
    {
        xor ^= i;
    }
    return xor;
}
int[] nums = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
int result = MissingNumber(nums);
Console.ReadLine();
//Output: 8