public class Solution
{
    //Using two pointers i and j to track the position of unique elements
    //Time: O(n) → Each element is visited once
    //Space: O(1) → In-place(no extra array)
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        int i = 0; int j = 1;
        while (j < nums.Length)
        {
            if (nums[i] != nums[j])
            {
                i++;
                nums[i] = nums[j];
            }
            j++;
        }
        return i + 1;
    }
}

//nums = [0,0,1,1,1,2,2,3,3,4]

//Step	i	j	nums[i]	nums[j]	Action	nums after change
//Start	0	1	0	0	same → skip	[0,0,1,1,1,2,2,3,3,4]
//1	0	2	0	1	diff → i=1, nums[1]=1	[0,1,1,1,1,2,2,3,3,4]
//2	1	3	1	1	same → skip	same
//3	1	4	1	1	same → skip	same
//4	1	5	1	2	diff → i=2, nums[2]=2	[0,1,2,1,1,2,2,3,3,4]
//5	2	6	2	2	same → skip	same
//6	2	7	2	3	diff → i=3, nums[3]=3	[0,1,2,3,1,2,2,3,3,4]
//7	3	8	3	3	same → skip	same
//8	3	9	3	4	diff → i=4, nums[4]=4	[0,1,2,3,4,2,2,3,3,4]nums = [0,0,1,1,1,2,2,3,3,4]

//Step	i	j	nums[i]	nums[j]	Action	nums after change
//Start	0	1	0	0	same → skip	[0,0,1,1,1,2,2,3,3,4]
//1	0	2	0	1	diff → i=1, nums[1]=1	[0,1,1,1,1,2,2,3,3,4]
//2	1	3	1	1	same → skip	same
//3	1	4	1	1	same → skip	same
//4	1	5	1	2	diff → i=2, nums[2]=2	[0,1,2,1,1,2,2,3,3,4]
//5	2	6	2	2	same → skip	same
//6	2	7	2	3	diff → i=3, nums[3]=3	[0,1,2,3,1,2,2,3,3,4]
//7	3	8	3	3	same → skip	same
//8	3	9	3	4	diff → i=4, nums[4]=4	[0,1,2,3,4,2,2,3,3,4]

//✅ Final i = 4 → length = i + 1 = 5
//Unique elements: [0,1,2,3,4]