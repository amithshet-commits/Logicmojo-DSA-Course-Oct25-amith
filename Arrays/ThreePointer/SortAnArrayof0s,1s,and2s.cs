static void SortColors(int[] nums)
{
    int low = 0; int mid = 0; int high = nums.Length - 1; int temp = 0;
    while (mid <= high)
    {
        if (nums[mid] == 0)
        {
            temp = nums[low];
            nums[low] = nums[mid];
            nums[mid] = temp;
            low++; mid++;
        }
        else if (nums[mid] == 1)
        {
            mid++;
        }
        else
        {
            temp = nums[mid];
            nums[mid] = nums[high];
            nums[high] = temp;
            high--;
        }
    }
}

int[] nums = { 2, 0, 2, 1, 1, 0 };
SortColors(nums);
Console.ReadLine();

//Sorted: [0,0,1,1,2,2]
//Dutch National Flag Algorithm (Optimal, In-Place, One Pass)

//This is the most efficient approach — O(n) time and O(1) space.

//We use three pointers:

//low → next position for 0

//mid → current element

//high → next position for 2

//Algorithm:

//Start with low = 0, mid = 0, high = n - 1

//While mid <= high:

//If nums[mid] == 0: swap nums[low] and nums[mid], increment both.

//If nums[mid] == 1: just move mid ahead.

//If nums[mid] == 2: swap nums[mid] and nums[high], decrement high.

//Visualization:

//Example: [2,0,2,1,1,0]

//low	mid	high	nums[mid]	Action	Array
//0	0	5	2	swap mid↔high	[0,0,2,1,1,2]
//0	0	4	0	swap low↔mid	[0,0,2,1,1,2]
//1	1	4	0	swap low↔mid	[0,0,2,1,1,2]
//2	2	4	2	swap mid↔high	[0,0,1,1,2,2]
//2	2	3	1	move mid	[0,0,1,1,2,2]
//2	3	3	1	move mid	[0,0,1,1,2,2]