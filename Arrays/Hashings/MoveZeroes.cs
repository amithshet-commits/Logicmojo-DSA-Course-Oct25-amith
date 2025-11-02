//Brute Force Approach:
//static void MoveZeroes(int[] nums)
//{
//    List<int> temp = new List<int>();

//    // Step 1: Store all non-zero elements
//    for (int i = 0; i < nums.Length; i++)
//    {
//        if (nums[i] != 0)
//        {
//            temp.Add(nums[i]);
//        }
//    }

//    // Step 2: Copy non-zero elements back to original array
//    for (int i = 0; i < temp.Count; i++)
//    {
//        nums[i] = temp[i];
//    }

//    // Step 3: Fill remaining positions with zeros
//    for (int i = temp.Count; i < nums.Length; i++)
//    {
//        nums[i] = 0;
//    }
//}

//Two Pointer Approach (Optimal):
static void MoveZeroes(int[] nums)
{
    int index = 0; int temp = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0)
        {
            temp = nums[i];
            nums[i] = nums[index];
            nums[index] = temp;
            index++;
        }
    }
}
int[] nums = { 0, 1, 0, 3, 12 };
MoveZeroes(nums);
Console.ReadLine();

//Optimal Approach (Two Pointers):
//Initialize a pointer (e.g., insertPosition or lastNonZeroFoundAt) to 0. This pointer will track the position where the next non-zero element should be placed.
//Iterate through the array with another pointer (e.g., i).
//If the element at nums[i] is not zero:
//Place this non-zero element at nums[insertPosition].
//Increment insertPosition.Optimal Approach (Two Pointers):
//Initialize a pointer (e.g., insertPosition or lastNonZeroFoundAt) to 0. This pointer will track the position where the next non-zero element should be placed.
//Iterate through the array with another pointer (e.g., i).
//If the element at nums[i] is not zero:
//Place this non-zero element at nums[insertPosition].
//Increment insertPosition.
